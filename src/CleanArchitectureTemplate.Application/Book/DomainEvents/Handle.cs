using MediatR;
using CleanArchitectureTemplate.Domain;
using CleanArchitectureTemplate.Shared.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.DomainEvents
{
    // BookAddedEventHandler: Just log the book added event without issuing any commands
    public class BookAddedEventHandler : INotificationHandler<BookAddedEvent>
    {
        public async Task Handle(BookAddedEvent notification, CancellationToken cancellationToken)
        {
            // Log the event (or perform other actions like sending notifications)
            Console.WriteLine($"Book added: {notification.Book.Title} by {notification.Book.Author}");

            // You can also send notifications, update a read model, etc.
            // No need to call commands here
        }
    }

    // BookSoldEventHandler: Just log the sale event and handle out-of-stock condition
    public class BookSoldEventHandler : INotificationHandler<BookSoldEvent>
    {
        public async Task Handle(BookSoldEvent notification, CancellationToken cancellationToken)
        {
            // Log the sale of the book
            Console.WriteLine($"Book sold: {notification.BookId}");

            // Check stock or handle out-of-stock condition
            // No need to call commands or queries here
        }
    }

    // BookStockAddedEventHandler: Just log the stock addition event
    public class BookStockAddedEventHandler : INotificationHandler<BookAddedStockEvent>
    {
        public async Task Handle(BookAddedStockEvent notification, CancellationToken cancellationToken)
        {
            // Log the stock addition event
            Console.WriteLine($"Stock added for Book ID: {notification.BookId}. Quantity: {notification.quantity}");

            // Handle further actions like sending notifications
            // No need to call commands here
        }
    }

    // BookPriceChangedEventHandler: Just log the price change event
    public class BookPriceChangedEventHandler : INotificationHandler<BookPriceChangedEvent>
    {
        public async Task Handle(BookPriceChangedEvent notification, CancellationToken cancellationToken)
        {
            // Log the price change event
            Console.WriteLine($"Price changed for Book ID: {notification.BookId}. New Price: {notification.NewPrice}");

            // Handle further actions like sending notifications
            // No need to call commands here
        }
    }
}
