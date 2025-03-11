

namespace CleanArchitectureTemplate.Shared.Interfaces
{
  public interface IReadRepository<T> where T: class, IAggregateRoot
  {
  }
}
