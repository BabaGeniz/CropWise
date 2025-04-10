using CropWise.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]


public class CropAnalysisController : ControllerBase
{
    private readonly IS3StorageService _s3StorageService;
    private readonly ICropAnalysisService _cropAnalysisService;

    public CropAnalysisController(IS3StorageService s3StorageService, ICropAnalysisService cropAnalysisService)
    {
        _s3StorageService = s3StorageService;
        _cropAnalysisService = cropAnalysisService;
    }

    [HttpPost]
    [Route("UploadImage")]
    [Consumes("multipart/form-data")] // Tells Swagger to allow file uploads
    public async Task<IActionResult> UploadImage(IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
            return BadRequest("No image uploaded.");

        string imageUrl = await _s3StorageService.UploadImageAsync(imageFile);
        return Ok(new { ImageUrl = imageUrl });
    }

    [HttpPost]
    [Route("SaveAnalysis")]
    public async Task<IActionResult> SaveAnalysis([FromBody] SaveAnalysisDTO saveAnalysisDTO)
    {
        if (saveAnalysisDTO == null)
            return BadRequest("Invalid analysis data.");

        await _cropAnalysisService.SaveAnalysisAsync(saveAnalysisDTO);
        return Ok("Analysis saved successfully.");
    }

    [HttpGet("analysis/{cropId}")]
    public async Task<IActionResult> GetCropAnalysisByCropId(int cropId)
    {
        var cropAnalysis = await _cropAnalysisService.GetCropAnalysisByIdAsync(cropId);
        if (cropAnalysis == null)
        {
            return NotFound("No analysis found for this crop.");
        }

        return Ok(cropAnalysis);
    }

}
