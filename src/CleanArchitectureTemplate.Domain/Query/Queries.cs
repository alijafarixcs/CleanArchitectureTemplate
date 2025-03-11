using CleanArchitectureTemplate.Shared;
using CleanArchitectureTemplate.Shared.Interfaces;
using MediatR;
 namespace CleanArchitectureTemplate.Domain.Query
{
    

public record GetEntityByIdQuery<T, TId>(TId Id) : IRequest<T> where T : Entity<TId>, IAggregateRoot;
}
