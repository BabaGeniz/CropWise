namespace CropWise.Models
{
    public class CropHealthReport
    {
        public int Id { get; set; }
        public int CropId { get; set; } // Foreign Key
        public int HealthScore { get; set; }
        public string AnalysisDetails { get; set; }
        public DateTime DateGenerated { get; set; }
        public string Recommendations { get; set; }

        // Navigation property
        public virtual Crop Crop { get; set; }

    }
}
