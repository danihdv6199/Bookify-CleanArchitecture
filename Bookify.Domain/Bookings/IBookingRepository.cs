using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;

public interface IBookingRepository
{
	Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	public Task<IReadOnlyList<Booking>> GetByDateRange(DateOnly startDate, DateOnly endDate, int[] ActiveBookingStatuses, CancellationToken cancellationToken = default);


	Task<bool> IsOverlappingAsync(
		Apartment apartment,
		DateRange duration,
		CancellationToken cancellationToken = default);

	void Add(Booking booking);
}