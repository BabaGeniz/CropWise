
using CropWise.Models;
public class CropAnalysisService:ICropAnalysisService
{

    private readonly ICropAnalysisRepository _cropAnalysisRepository;
    private readonly ICropRepository _cropRepository;
    public CropAnalysisService(ICropAnalysisRepository cropAnalysisRepository, ICropRepository cropRepository)
    {
        _cropAnalysisRepository = cropAnalysisRepository;
        _cropRepository = cropRepository;
    }

    public async Task SaveAnalysisAsync(SaveAnalysisDTO saveAnalysisDTO)
    {
        // Create and save the new Crop entity
        var crop = new Crop
        {
            FarmerId = saveAnalysisDTO.FarmerId,
            CropName = saveAnalysisDTO.CropName,
            CropType = saveAnalysisDTO.CropType,
            DatePlanted = saveAnalysisDTO.DatePlanted,
            ImagePath = saveAnalysisDTO.ImagePath
        };

        // Save the crop in the repository (database)
        await _cropRepository.AddAsync(crop);

        // Create and save the new CropAnalysis entity
        var cropAnalysis = new CropAnalysis
        {
            CropId = crop.Id,  // Link the analysis to the newly created crop
            HealthRating = saveAnalysisDTO.HealthRating,
            Analysis = saveAnalysisDTO.Analysis,
            Recommendation = saveAnalysisDTO.Recommendation,
            CreatedAt = DateTime.UtcNow  // Set the creation date of the analysis
        };

        // Save the crop analysis in the repository (database)
        await _cropAnalysisRepository.AddAsync(cropAnalysis);
    }
    public async Task<CropAnalysis> GetCropAnalysisByCropIdAsync(int cropId)
    {
        // Retrieves the crop analysis based on cropId from the repository
        return await _cropAnalysisRepository.GetByCropIdAsync(cropId);
    }

    public async Task<CropAnalysis> GetCropAnalysisByIdAsync(int Id)
    {
        // Retrieves the crop analysis based on Id from the repository
        return await _cropAnalysisRepository.GetByIdAsync(Id);
    }
}

