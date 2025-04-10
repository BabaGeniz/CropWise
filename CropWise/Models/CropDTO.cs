namespace CropWise.Models
{
    public class CropDTO
    {
        public int FarmerId { get; set; }
        public string CropName { get; set; }  // Name of the crop (e.g., Wheat, Corn)
        public string? CropType { get; set; }  // Type of the crop (e.g., Grain, Vegetable)
        public DateTime DatePlanted { get; set; }  // Date the crop was planted
        public string? ImagePath { get; set; } // Image path for crop
    }
}
