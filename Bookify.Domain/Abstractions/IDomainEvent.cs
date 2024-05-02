using MediatR;

namespace Bookify.Domain.Abstractions
{
	/*
	 * Mediator notifications are use to implement the publish subscribe pattern
	 * Recap: Represents all of domain events
	 * Its used qhen something ocurred in the domain and I want to notify other components that something has happened.
	 * Can have one or more subscribers for the event that want to handled
	 */
	public interface IDomainEvent : INotification
	{
	}
}
