using CleanArchitectureTemplate.Shared;

namespace CleanArchitectureTemplate.Domain;

public class Book : AggregateRoot<Guid>
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public Price Price { get; private set; }
    private int _stock; // Encapsulate Stock

    public int Stock => _stock; // Read-only public accessor
    private Book():base(Guid.NewGuid()) //EFCORE
    {
    }
    private Book(Guid id, string title, string author, decimal price) : base(id)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty.");
        if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Author cannot be empty.");
        if (price <= 0) throw new ArgumentException("Price must be greater than zero.");

        Title = title;
        Author = author;
        Price = new Price(price);
        _stock = 0;
    }

    public static Book AddBook(string title, string author, decimal price)
    {
        var book = new Book(Guid.NewGuid(), title, author, price);
        book.RaiseDomainEvent(new BookAddedEvent(book.Id, title, author, price,book));
        return book;
    }

    public void SellBook(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (_stock < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        _stock -= quantity;
        RaiseDomainEvent(new BookSoldEvent(Id, quantity));
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("New price must be greater than zero.");

        Price = new Price(newPrice);
        RaiseDomainEvent(new BookPriceChangedEvent(Id, newPrice));
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Stock quantity must be greater than zero.");

        _stock += quantity;
        RaiseDomainEvent(new BookAddedStockEvent(Id, quantity)); // Consistent event naming
    }
}
