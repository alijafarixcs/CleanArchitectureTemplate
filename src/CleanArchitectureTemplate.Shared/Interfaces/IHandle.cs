using System.Threading.Tasks;
using MediatR;


namespace CleanArchitectureTemplate.Shared.Interfaces
{
  public interface IHandle<T>  :INotificationHandler<T> where T : BaseDomainEvent
  {
    Task HandleAsync(T args);
  }
}
