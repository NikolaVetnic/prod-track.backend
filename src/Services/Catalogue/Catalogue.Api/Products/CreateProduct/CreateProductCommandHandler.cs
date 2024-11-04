namespace Catalogue.Api.Products.CreateProduct;

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Price = command.Price,
            PurchaseDate = command.PurchaseDate,
            Description = command.Description,
        };
 
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}

public record CreateProductCommand(
    string Name,
    List<string> Category,
    decimal Price,
    DateTime PurchaseDate,
    string Description) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);