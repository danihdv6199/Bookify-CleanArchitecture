using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events
{
	public sealed record BookingRejectedDomainInEvent(Guid BookingId) : IDomainEvent;
}
