using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events
{
	public sealed record BookingCancelledDomainInEvent(Guid BookingId) : IDomainEvent;
}
