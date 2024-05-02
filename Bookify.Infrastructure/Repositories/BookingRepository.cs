using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories
{
	internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
	{
		private static readonly BookingStatus[] ActiveBookingStatuses =
		{
			BookingStatus.Reserved,
			BookingStatus.Confirmed,
			BookingStatus.Completed
		};

		public BookingRepository(ApplicationDbContext dbContext)
			: base(dbContext)
		{

		}

		public async Task<IReadOnlyList<Booking>> GetByDateRange(DateOnly startDate, DateOnly endDate, int[] ActiveBookingStatuses, CancellationToken cancellationToken = default)
		{

			return await DbContext
				.Set<Booking>()
				.Where(a => a.Duration.Start == startDate && a.Duration.End == endDate && a.Status.Equals(ActiveBookingStatuses))
				.ToListAsync();
		}

		public async Task<bool> IsOverlappingAsync(
			Apartment apartment,
			DateRange duration,
			CancellationToken cancellationToken = default)
		{
			return await DbContext
				.Set<Booking>()
				.AnyAsync(
				booking =>
				booking.AparmentId == apartment.Id &&
				booking.Duration.Start <= duration.End &&
				booking.Duration.End >= duration.Start &&
				ActiveBookingStatuses.Contains(booking.Status),
				cancellationToken);

		}
	}
}
