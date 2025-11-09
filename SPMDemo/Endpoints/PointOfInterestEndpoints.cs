using Microsoft.AspNetCore.Mvc;
using SPMDemo.Models.Dtos;
using SPMDemo.Models.Entities;
using SPMDemo.Models.Services.Infrastructure;

namespace SPMDemo.Endpoints
{
    internal static class PointOfInterestEndpoints
    {
        public static async Task<IResult> GetList([FromServices] IUnitOfWork unitOfWork)
        {
            IEnumerable<PointOfInterest> list = await unitOfWork.PointOfInterests.GetAllAsync();

            IEnumerable<PointOfInterestDto> dtoList = list.Select(poi => new PointOfInterestDto
            {
                Id = poi.Id,
                Name = poi.Name,
                Description = poi.Description,
                Latitude = poi.Latitude,
                Longitude = poi.Longitude
            });

            return TypedResults.Ok(dtoList);
        }

        public static async Task<IResult> GetById(
            [FromServices] IUnitOfWork unitOfWork,
            int id)
        {
            PointOfInterest point = await unitOfWork.PointOfInterests.GetAsync(id);

            if (point == null)
            {
                return TypedResults.NotFound();
            }

            PointOfInterestDto dto = new()
            {
                Id = point.Id,
                Name = point.Name,
                Description = point.Description,
                Latitude = point.Latitude,
                Longitude = point.Longitude
            };

            return TypedResults.Ok(dto);
        }
    }
}
