﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users
{
	public static class UserErrors
	{
		public static Error NotFound = new(
			"Booking.Found",
			"The bookin with the specified identifier was not found");
		public static Error OverLap = new(
			"Booking.Overlap",
			"The bookin with the specified identifier was not found");
		public static Error NotReserved = new(
			"Booking.NotReserved",
			"The bookin with the specified identifier was not found");
		public static Error NotConfirmed = new(
			"Booking.NotConfirmed",
			"The bookin with the specified identifier was not found");
		public static Error AlreadyStarted = new(
			"Booking.AlreadyStarted",
			"The bookin with the specified identifier was not found");
	}
}
