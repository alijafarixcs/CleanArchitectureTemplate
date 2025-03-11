using CleanArchitectureTemplate.Domain.Query;
using CleanArchitectureTemplate.Shared;
using CleanArchitectureTemplate.Shared.Interfaces;
using MediatR;

public class GetEntityByIdHandler<T, TId> : IRequestHandler<GetEntityByIdQuery<T, TId>, T>
    where T : Entity<TId>, IAggregateRoot
{
    private readonly IRepository _repository;

    public GetEntityByIdHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<T> Handle(GetEntityByIdQuery<T, TId> request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync<T, TId>(request.Id);
    }
}
