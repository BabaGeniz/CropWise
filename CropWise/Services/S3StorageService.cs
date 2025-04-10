using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;


public class S3StorageService : IS3StorageService
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public S3StorageService(IConfiguration configuration)
    {
        _s3Client = new AmazonS3Client(
            configuration["AWS:AccessKey"],
            configuration["AWS:SecretKey"],
            RegionEndpoint.GetBySystemName(configuration["AWS:Region"])
        );

        _bucketName = configuration["AWS:BucketName"];
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        var fileName = $"{Guid.NewGuid()}_{file.FileName}"; // Unique filename
        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName,
            InputStream = file.OpenReadStream(),
            ContentType = file.ContentType,
        };

        await _s3Client.PutObjectAsync(request);

        // Return the public URL of the uploaded image
        return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
    }
    public async Task<string> GetPresignedUrlAsync(string bucketName, string fileName)
    {
        var request = new GetPreSignedUrlRequest
        {
            BucketName = bucketName,
            Key = fileName,
            Expires = DateTime.UtcNow.AddMinutes(30), // URL expiration time
            Verb = HttpVerb.PUT // Allow PUT operation for uploading
        };

        string url = _s3Client.GetPreSignedURL(request);
        return url;
    }
}

