using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class FileUploadOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileParameters = context.ApiDescription.ActionDescriptor.Parameters
            .Where(p => p.ParameterType == typeof(IFormFile) || p.ParameterType == typeof(IFormFile[]));

        foreach (var parameter in fileParameters)
        {
            var fileSchema = new OpenApiSchema
            {
                Type = "string",
                Format = "binary"
            };

            operation.RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["multipart/form-data"] = new OpenApiMediaType
                    {
                        Schema = fileSchema
                    }
                }
            };
        }
    }
}

