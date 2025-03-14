using System;
using MediatR;

namespace CleanArchitectureTemplate.Shared
{
  public record BaseDomainEvent : INotification
  {
    public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
  }
}
