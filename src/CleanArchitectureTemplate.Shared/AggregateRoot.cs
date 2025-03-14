using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Shared.Interfaces;


namespace CleanArchitectureTemplate.Shared
{
    public abstract class AggregateRoot<Tid> : Entity<Tid>,IAggregateRoot
    {
        private readonly List<BaseDomainEvent> _domainEvents = new();
        protected AggregateRoot(Tid Id) : base(Id)
        {

        }
       

        public long Version { get; private set; }
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
            Version++;
        }

    }
}
