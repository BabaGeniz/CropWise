using CropWise.Models;

public interface ICropAnalysisRepository
{
	
	// Get a Crop Analysis by CropId
	Task<CropAnalysis> GetByCropIdAsync(int cropId);

	// Get a Crop Analysis by AnalysisId (Id)
	Task<CropAnalysis> GetByIdAsync(int id);

	// Add a new Crop Analysis
	Task<CropAnalysis> AddAsync(CropAnalysis cropAnalysis);

	// Delete a Crop Analysis by Id
	Task<bool> DeleteAsync(int id);
}
