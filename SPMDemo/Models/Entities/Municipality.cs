namespace SPMDemo.Models.Entities
{
    public class Municipality
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }

        #region One-to-Many with PointOfInterest
        public ICollection<PointOfInterest> PointOfInterests { get; } = []; // Collection navigation containing dependents
        #endregion One-to-Many with PointOfInterest
    }
}
