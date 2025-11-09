namespace SPMDemo.Models.Entities
{
    public class PointOfInterest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }

        #region One-to-Many with Municipality
        public int MunicipalityId { get; set; } // Required foreign key property
        public Municipality Municipality { get; set; } = null!; // Required reference navigation to principal
        #endregion
    }
}
