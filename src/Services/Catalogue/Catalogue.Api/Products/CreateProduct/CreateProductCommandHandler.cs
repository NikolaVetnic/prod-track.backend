namespace Catalogue.Api.Products.CreateProduct;

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
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

        //save to database

        return new CreateProductResult(Guid.NewGuid());
    }
}

public record CreateProductCommand(
    string Name,
    List<string> Category,
    decimal Price,
    DateTime PurchaseDate,
    string Description) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);