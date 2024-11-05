namespace Catalogue.Api.Products.GetProductById;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}",
                async (Guid id, ISender sender) =>
                {
                    var result = await sender.Send(new GetProductByIdQuery(id));
                    var response = result.Adapt<GetProductByIdResponse>();

                    return Results.Ok(response);
                })
            .WithName("GetProductsById")
            .Produces<GetProductByIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products By Id")
            .WithDescription("Get Products By Id");
    }
}

//public record GetProductByIdRequest();
public record GetProductByIdResponse(Product Product);
