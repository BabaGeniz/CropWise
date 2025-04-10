using CropWise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IS3StorageService
{
    Task<string> UploadImageAsync(IFormFile file);
}

