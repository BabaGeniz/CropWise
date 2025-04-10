namespace CropWise.Models
{

    public class Crop
    {
        public int Id { get; set; }  // Primary Key
        public int FarmerId { get; set; } // Foreign Key to Farmer
        public string CropName { get; set; }  // Name of the crop (e.g., Wheat, Corn)
        public string CropType { get; set; }  // Type of the crop (e.g., Grain, Vegetable)
        public DateTime DatePlanted { get; set; }  // Date the crop was planted

        // Path or URL to the crop's image
        public string? ImagePath { get; set; }  // Can store file path or URL to the image

        // Navigation property linking to the Farm
        public virtual CropHealthReport CropHealthReport { get; set; }
        public virtual ICollection<CropAnalysis> Analyses { get; set; }
    }
}
