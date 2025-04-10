using CropWise.Models;

public interface ICropAnalysisService
{
	Task SaveAnalysisAsync(SaveAnalysisDTO saveAnalysisDTO);
	Task<CropAnalysis> GetCropAnalysisByCropIdAsync(int cropId);
	Task<CropAnalysis> GetCropAnalysisByIdAsync(int Id);
}