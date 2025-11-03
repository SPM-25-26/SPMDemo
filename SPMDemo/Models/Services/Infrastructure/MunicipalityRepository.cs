using SPMDemo.Data;
using SPMDemo.Models.Entities;

namespace SPMDemo.Models.Services.Infrastructure
{
    public class MunicipalityRepository(ApplicationDbContext context) : Repository<Municipality>(context), IMunicipalityRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }
    }
}
