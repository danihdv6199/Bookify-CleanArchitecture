using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users.Events
{
	/*
	 * Recap: Create an event; this is an event that return the UserId
	 */
	public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}
