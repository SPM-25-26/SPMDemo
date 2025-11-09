using SPMDemo.Models.Dtos;
using SPMDemo.Models.Entities;
using SPMDemo.Models.Exceptions;
using SPMDemo.Models.Services.Infrastructure;

namespace SPMDemo.Models.Services.Application.PointOfInterests
{
    public class PointOfInterestService(
        IUnitOfWork unitOfWork,
        ILogger<PointOfInterestService> logger) : IPointOfInterestService
    {
        public async Task<IEnumerable<PointOfInterestDto>> GetAllAsync()
        {
            IEnumerable<PointOfInterest> list = await unitOfWork.PointOfInterests.GetAllAsync();

            return list.Select(poi => new PointOfInterestDto
            {
                Id = poi.Id,
                Name = poi.Name,
                Description = poi.Description,
                Latitude = poi.Latitude,
                Longitude = poi.Longitude
            });
        }

        public async Task<PointOfInterestDto> GetByIdAsync(int id)
        {
            PointOfInterest point = await unitOfWork.PointOfInterests.GetAsync(id);

            if (point is null)
            {
                logger.LogWarning("Point of Interest with ID {id} not found.", id);
                throw new NotFoundException($"Point of Interest with ID {id} not found.");
            }

            return new PointOfInterestDto()
            {
                Id = point.Id,
                Name = point.Name,
                Description = point.Description,
                Latitude = point.Latitude,
                Longitude = point.Longitude
            };
        }
    }
}
