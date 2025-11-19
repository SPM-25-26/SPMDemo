using Microsoft.AspNetCore.Mvc;
using SPMDemo.Models.Dtos;
using SPMDemo.Models.Exceptions;
using SPMDemo.Models.Services.Application.PointOfInterests;

namespace SPMDemo.Endpoints
{
    internal static class PointOfInterestEndpoints
    {
        public static async Task<IResult> GetList(
            [FromServices] IPointOfInterestService pointOfInterestService)
        {
            IEnumerable<PointOfInterestDto> poi = await pointOfInterestService.GetAllAsync();
            return TypedResults.Ok(poi);
        }

        public static async Task<IResult> GetById(
            [FromServices] IPointOfInterestService pointOfInterestService,
            int id)
        {
            try
            {
                PointOfInterestDto dto = await pointOfInterestService.GetByIdAsync(id);
                return TypedResults.Ok(dto);
            }
            catch (NotFoundException)
            {
                return TypedResults.NotFound($"Point of interest with id {id} is not present in the db.");
            }
        }

        public static async Task<IResult> Create(
            [FromServices] IPointOfInterestService pointOfInterestService,
            PointOfInterestCreateDto input)
        {
            PointOfInterestDto created = await pointOfInterestService.CreateAsync(input);
            return TypedResults.Created($"/api/point-of-interests/{created.Id}", created);
        }

        public static async Task<IResult> Update(
            [FromServices] IPointOfInterestService pointOfInterestService,
            int id,
            PointOfInterestUpdateDto input)
        {
            try
            {
                PointOfInterestDto updated = await pointOfInterestService.UpdateAsync(id, input);
                return TypedResults.Ok(updated);
            }
            catch (NotFoundException)
            {
                return TypedResults.NotFound($"Point of interest with id {id} not found.");
            }
        }

        public static async Task<IResult> Delete(
            [FromServices] IPointOfInterestService pointOfInterestService,
            int id)
        {
            try
            {
                await pointOfInterestService.DeleteAsync(id);
                return TypedResults.NoContent();
            }
            catch (NotFoundException)
            {
                return TypedResults.NotFound($"Point of interest with id {id} not found.");
            }
        }
    }

}
