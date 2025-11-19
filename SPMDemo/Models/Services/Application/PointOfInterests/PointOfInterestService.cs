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

        public async Task<PointOfInterestDto> CreateAsync(PointOfInterestCreateDto dto)
        {
            // Map DTO to Entity
            PointOfInterest entity = new()
            {
                Name = dto.Name,
                Description = dto.Description,
                ShortDescription = dto.ShortDescription,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                MunicipalityId = dto.MunicipalityId
            };

            // Add entity to the repository
            unitOfWork.PointOfInterests.Add(entity);

            // Persist changes
            await unitOfWork.CompleteAsync();

            // Map back to DTO
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude
            };
        }

        public async Task<PointOfInterestDto> UpdateAsync(int id, PointOfInterestUpdateDto dto)
        {
            // Load existing entity
            PointOfInterest? entity = await unitOfWork.PointOfInterests.GetAsync(id) ?? throw new NotFoundException($"Point of interest with id {id} not found.");

            // Update entity values
            entity.Name = dto.Name;

            if (!string.IsNullOrEmpty(dto.Description))
            {
                entity.Description = dto.Description;
            }

            if (!string.IsNullOrEmpty(dto.ShortDescription))
            {
                entity.Description = dto.ShortDescription;
            }

            // Save changes
            await unitOfWork.CompleteAsync();

            // Return updated DTO
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude
            };
        }

        public async Task DeleteAsync(int id)
        {
            // Load the entity
            PointOfInterest? entity = await unitOfWork.PointOfInterests.GetAsync(id) ?? throw new NotFoundException($"Point of interest with id {id} not found.");

            // Remove entity
            unitOfWork.PointOfInterests.Remove(entity);

            // Save changes
            await unitOfWork.CompleteAsync();
        }

    }
}
