namespace SPMDemo.Models.Dtos
{
    public class PointOfInterestUpdateDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ShortDescription { get; set; }
    }
}
