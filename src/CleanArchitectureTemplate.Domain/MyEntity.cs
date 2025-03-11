using CleanArchitectureTemplate.Shared;

namespace CleanArchitectureTemplate.Domain;

public class MyEntity : Entity<Guid>
{
    public MyEntity(Guid id) : base(id)
    {
    }
}
