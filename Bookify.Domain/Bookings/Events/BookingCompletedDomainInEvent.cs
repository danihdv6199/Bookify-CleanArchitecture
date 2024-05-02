﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events
{
	public sealed record BookingCompletedDomainInEvent(Guid BookingId) : IDomainEvent;
}
