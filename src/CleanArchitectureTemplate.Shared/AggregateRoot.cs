using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Shared.Interfaces;
using PluralsightDdd.SharedKernel;

namespace CleanArchitectureTemplate.Shared
{
    public abstract class AggregateRoot : Entity<Guid>,IAggregateRoot
    {
        protected AggregateRoot():base(Guid.NewGuid())
        {
            
        }
        protected AggregateRoot(Guid Id) : base(Id)
        {

        }
        private readonly List<BaseDomainEvent> _changes = new List<BaseDomainEvent>();

        public int Version { get; private set; }

        public IReadOnlyCollection<BaseDomainEvent> GetChanges()
        {
            return _changes.AsReadOnly();
        }
         
        public void ClearChanges()
        {
            _changes.Clear();
        }

     private readonly List<BaseDomainEvent> _domainEvents = new();

 

    public Guid Id { get; init; }

    public IReadOnlyList<BaseDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    }
}
