namespace SPMDemo.Models.Services.Infrastructure
{
    public interface IUnitOfWork
    {
        IPointOfInterestRepository PointOfInterests { get; }
        IMunicipalityRepository Municipalities { get; }

        Task CompleteAsync();
    }
}
