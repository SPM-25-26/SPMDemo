namespace SPMDemo.Models.Dtos
{
    public class PointOfInterestCreateDto
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string ShortDescription { get; set; }

        public required int MunicipalityId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

    }
}
