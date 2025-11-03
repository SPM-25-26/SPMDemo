using SPMDemo.Models.Dtos;

namespace SPMDemo.Endpoints
{
    internal static class PointOfInterestMap
    {
        public static IEndpointRouteBuilder MapPointOfInterest(this IEndpointRouteBuilder builder)
        {
            RouteGroupBuilder groupBuilder = builder.MapGroup("/api/point-of-interest");

            groupBuilder.MapGet("/", PointOfInterestEndpoints.GetList)
                .Produces<IEnumerable<PointOfInterestDto>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithOpenApi(op =>
                {
                    op.Summary = "Get POI list";
                    return op;
                });

            groupBuilder.MapGet("/{id}", PointOfInterestEndpoints.GetById)
                .Produces<PointOfInterestDto>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithOpenApi(op =>
                {
                    op.Summary = "Get POI detail.";
                    op.Parameters[0].Description = "The poi identifier";
                    return op;
                });

            return builder;
        }
    }
}
