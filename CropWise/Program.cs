using CropWise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework to use SQL Server with the connection string
builder.Services.AddDbContext<CropWiseDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-IEIE0FB\\SQLEXPRESS;Database=CropWiseDB;Trusted_Connection=True;TrustServerCertificate=True");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.ASCII.GetBytes(jwtSettings.GetValue<string>("SecretKey"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
        ValidAudience = jwtSettings.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ClockSkew = TimeSpan.Zero
    };
});

// Add AWS SDK dependencies
builder.Services.AddSingleton<IAmazonS3, AmazonS3Client>();


// Register Repositories
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<ICropAnalysisRepository, CropAnalysisRepository>();

// Register Services
builder.Services.AddScoped<IS3StorageService, S3StorageService>();
builder.Services.AddScoped<IAIProcessorService, AIProcessorService>();
builder.Services.AddScoped<ICropAnalysisService, CropAnalysisService>();



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CropWise API", Version = "v1" });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CropWise V1");
    c.RoutePrefix = string.Empty; // Set the Swagger UI at the app's root
});

app.UseRouting();
app.UseCors("AllowAllOrigins"); // Enable CORS
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
