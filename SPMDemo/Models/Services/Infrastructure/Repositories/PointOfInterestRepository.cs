using SPMDemo.Data;
using SPMDemo.Models.Entities;

namespace SPMDemo.Models.Services.Infrastructure.Repositories
{
    public class PointOfInterestRepository(ApplicationDbContext context) : Repository<PointOfInterest>(context), IPointOfInterestRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }
    }
}
