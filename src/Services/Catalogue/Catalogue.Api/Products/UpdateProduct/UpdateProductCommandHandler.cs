namespace Catalogue.Api.Products.UpdateProduct;

internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductsCommandHandler.Handle called with {@Command}", command);
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException();

        product.Name = command.Name;
        product.Category = command.Category;
        product.Price = command.Price;
        product.PurchaseDate = command.PurchaseDate;
        product.Description = command.Description;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}

public record UpdateProductCommand(
    Guid Id,
    string Name,
    List<string> Category,
    decimal Price,
    DateTime PurchaseDate,
    string Description) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);
