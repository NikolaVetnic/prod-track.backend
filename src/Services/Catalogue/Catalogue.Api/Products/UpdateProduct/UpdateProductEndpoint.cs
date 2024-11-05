﻿namespace Catalogue.Api.Products.UpdateProduct;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products",
                async (UpdateProductRequest request, ISender sender) =>
                {
                    var command = request.Adapt<UpdateProductCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<UpdateProductResponse>();

                    return Results.Ok(response);
                })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
    }
}

public record UpdateProductRequest(
    Guid Id,
    string Name,
    List<string> Category,
    decimal Price,
    DateTime PurchaseDate,
    string Description
    );

public record UpdateProductResponse(bool IsSuccess);
