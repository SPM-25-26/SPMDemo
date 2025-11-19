using SPMDemo.Models.Dtos;

namespace SPMDemo.Endpoints
{
    internal static class PointOfInterestMap
    {
        public static IEndpointRouteBuilder MapPointOfInterest(this IEndpointRouteBuilder builder)
        {
            RouteGroupBuilder groupBuilder = builder
                .MapGroup("/api/point-of-interests")
                .RequireAuthorization();

            // GET LIST
            groupBuilder.MapGet("/", PointOfInterestEndpoints.GetList)
                .Produces<IEnumerable<PointOfInterestDto>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithOpenApi(op =>
                {
                    op.Summary = "Get POI list";
                    return op;
                });

            // GET BY ID
            groupBuilder.MapGet("/{id}", PointOfInterestEndpoints.GetById)
                .Produces<PointOfInterestDto>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithOpenApi(op =>
                {
                    op.Summary = "Get POI detail.";
                    op.Parameters[0].Description = "The POI identifier";
                    return op;
                });

            // CREATE (POST)
            groupBuilder.MapPost("/", PointOfInterestEndpoints.Create)
                .Produces<PointOfInterestDto>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithOpenApi(op =>
                {
                    op.Summary = "Create a new point of interest.";
                    return op;
                });

            // UPDATE (PATCH)
            groupBuilder.MapPatch("/{id}", PointOfInterestEndpoints.Update)
                .Produces<PointOfInterestDto>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithOpenApi(op =>
                {
                    op.Summary = "Update an existing point of interest.";
                    op.Parameters[0].Description = "The POI identifier";
                    return op;
                });

            // DELETE
            groupBuilder.MapDelete("/{id}", PointOfInterestEndpoints.Delete)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithOpenApi(op =>
                {
                    op.Summary = "Delete a point of interest.";
                    op.Parameters[0].Description = "The POI identifier";
                    return op;
                });

            return builder;
        }
    }

}
