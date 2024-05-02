using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;

namespace Bookify.Application.Bookings.GetBooking
{
	internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
	{

		private readonly IUnitOfWork _unitOfWork;
		private readonly IBookingRepository _bookingRepository;
		public GetBookingQueryHandler(IUnitOfWork unitOfWork, IBookingRepository bookingRepository)
		{
			_unitOfWork = unitOfWork;
			_bookingRepository = bookingRepository;
		}

		public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
		{
			Booking booking = await _bookingRepository.GetByIdAsync(request.BookingId)
				?? throw new Exception("");

			return new BookingResponse
			{
				ApartmentId = booking.ApartmentId,
				Id = booking.Id,
				DurationEnd = booking.Duration.End,
				AmenitiesUpChargeAmount = booking.AmenitiesUpCharge.Amount,
				AmenitiesUpChargeCurrency = booking.AmenitiesUpCharge.Currency.Code,
				CleaningFeeAmount = booking.CleaningFee.Amount,
				CleaningFeeCurrency = booking.CleaningFee.Currency.Code,
				CreatedOnUtc = booking.CreatedOnUtc,
				DurationStart = booking.Duration.Start,
				PriceAmount = booking.PriceForPeriod.Amount,
				PriceCurrency = booking.PriceForPeriod.Currency.Code,
				Status = (int)booking.Status,
				TotalPriceAmount = booking.TotalPrice.Amount,
				TotalPriceCurrency = booking.TotalPrice.Currency.Code,
				UserId = booking.UserId,
			};
		}
	}
}
