using CropWise.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CropsController : ControllerBase
{
    private readonly ICropRepository _cropRepository;

    public CropsController(ICropRepository cropRepository)
    {
        _cropRepository = cropRepository;
    }

    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var crops = await _cropRepository.GetAllAsync();
        return Ok(crops);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetCropById(int id)
    {
        var crop = await _cropRepository.GetByIdAsync(id);
        if (crop == null)
        {
            return NotFound("Crop not found.");
        }

        return Ok(crop);
    }

    [HttpPost]

    public async Task<IActionResult> Add(CropDTO cropdto)
    {
        // Manual mapping from CropDTO to Crop entity
        var crop = new Crop
        {
            FarmerId = cropdto.FarmerId,
            CropName = cropdto.CropName,
            CropType = cropdto.CropType,
            DatePlanted = cropdto.DatePlanted,
            ImagePath = cropdto.ImagePath,
        };

        // Add the crop entity to the repository
        await _cropRepository.AddAsync(crop);

        // Return the added crop (or you could return a custom response)
        return Ok(crop);
    }


    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await _cropRepository.DeleteAsync(id);
        return NoContent();
    }
}
