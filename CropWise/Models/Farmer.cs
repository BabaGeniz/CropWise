namespace CropWise.Models
{
    public class Farmer
    {
        public int Id { get; set; }  // Primary Key
        public int UserId { get; set; } //Foreign Key to User table
        public string FarmName { get; set; }
        public string FarmLocation { get; set; }


    }
}
