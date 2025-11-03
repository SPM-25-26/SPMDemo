namespace SPMDemo.Models.Dtos
{
    public class PointOfInterestDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
    }
}
