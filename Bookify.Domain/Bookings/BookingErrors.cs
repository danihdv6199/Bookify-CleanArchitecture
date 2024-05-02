using Bookify.Domain.Abstractions;
namespace Bookify.Domain.Bookings
{
	public static class BookingErrors
	{
		public static Error NotFound = new(
			"Booking.Found",
			"The bookin with the specified identifier was not found");
		public static Error OverLap = new(
			"Booking.Overlap",
			"The currentbooking is overlapping with an existing one");
		public static Error NotReserved = new(
			"Booking.NotReserved",
			"the booking is not pending");
		public static Error NotConfirmed = new(
			"Booking.NotConfirmed",
			"The bookin is not confirmed");
		public static Error AlreadyStarted = new(
			"Booking.AlreadyStarted",
			"The bookin has already started");
	}
}
