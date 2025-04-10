namespace CropWise.Models
{
    public class CropAnalysis
    {
        public int Id { get; set; }
        public int CropId { get; set; } // Foreign Key to Crop
        public string HealthRating { get; set; }
        public string Analysis { get; set; }
        public string Recommendation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public Crop Crop { get; set; }
    }
}

