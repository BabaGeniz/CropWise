namespace CropWise.Models
{
    public class CropAnalysisDTO
    {
        public int CropId { get; set; }
        public string HealthRating { get; set; }
        public string Analysis { get; set; }
        public string Recommendation { get; set; }
    }
    public class SaveAnalysisDTO
    {
        public int FarmerId { get; set; }
        public string CropName { get; set; }
        public string CropType { get; set; }
        public DateTime DatePlanted { get; set; }
        public string? ImagePath { get; set; }

        public string HealthRating { get; set; }
        public string Analysis { get; set; }
        public string Recommendation { get; set; }
    }
}
