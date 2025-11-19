using SPMDemo.Models.Dtos;

namespace SPMDemo.Models.Services.Application.PointOfInterests
{
    public interface IPointOfInterestService
    {
        Task<PointOfInterestDto> CreateAsync(PointOfInterestCreateDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<PointOfInterestDto>> GetAllAsync();
        Task<PointOfInterestDto> GetByIdAsync(int id);
        Task<PointOfInterestDto> UpdateAsync(int id, PointOfInterestUpdateDto dto);
    }
}
