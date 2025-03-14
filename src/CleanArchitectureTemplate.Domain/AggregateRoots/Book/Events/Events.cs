using CleanArchitectureTemplate.Domain;
using CleanArchitectureTemplate.Shared;

public record BookAddedEvent(Guid Id,string Title, string Author, decimal Price,Book Book) : BaseDomainEvent;

public record BookSoldEvent(Guid BookId, int Quantity) : BaseDomainEvent;

public record BookPriceChangedEvent(Guid BookId, decimal NewPrice) : BaseDomainEvent;
public record BookAddedStockEvent(Guid BookId, int quantity) : BaseDomainEvent;