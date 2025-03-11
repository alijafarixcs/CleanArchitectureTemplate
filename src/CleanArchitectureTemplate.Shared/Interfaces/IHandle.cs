using System.Threading.Tasks;
using PluralsightDdd.SharedKernel;

namespace CleanArchitectureTemplate.Shared.Interfaces
{
  public interface IHandle<T> where T : BaseDomainEvent
  {
    Task HandleAsync(T args);
  }
}
