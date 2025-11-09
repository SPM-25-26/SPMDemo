using SPMDemo.Models.Dtos;

namespace SPMDemo.Models.Services.Application.PointOfInterests
{
    public interface IPointOfInterestService
    {
        Task<IEnumerable<PointOfInterestDto>> GetAllAsync();
        Task<PointOfInterestDto> GetByIdAsync(int id);
    }
}
