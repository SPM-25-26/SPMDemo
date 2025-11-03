using SPMDemo.Data;

namespace SPMDemo.Models.Services.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PointOfInterests = new PointOfInterestRepository(_context);
            Municipalities = new MunicipalityRepository(_context);
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IPointOfInterestRepository PointOfInterests { get; }
        public IMunicipalityRepository Municipalities { get; }
    }
}
