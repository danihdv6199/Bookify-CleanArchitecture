using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;

namespace Bookify.Application.Apartments.SearchApartments
{
	internal sealed class SearchApartmentQueryHandler : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
	{
		private readonly IApartmentRepository _apartmentRepository;
		private readonly IBookingRepository _bookingRepository;

		private static readonly int[] ActiveBookingStatuses =
		{
			(int)BookingStatus.Reserved,
			(int)BookingStatus.Confirmed,
			(int)BookingStatus.Cancelled,
		};

		public SearchApartmentQueryHandler(IApartmentRepository apartmentRepository, IBookingRepository bookingRepository)
		{
			_apartmentRepository = apartmentRepository;
			_bookingRepository = bookingRepository;
		}

		public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentsQuery request, CancellationToken cancellationToken)
		{
			if (request.StartDate > request.EndDate)
				return new List<ApartmentResponse>();

			IReadOnlyList<Booking> bookings = await _bookingRepository.GetByDateRange(request.StartDate, request.EndDate, ActiveBookingStatuses)
				?? throw new Exception("error");
			List<Apartment> apartments = new List<Apartment>();
			foreach (Booking booking in bookings)
			{
				apartments.Add(await _apartmentRepository.GetByIdAsync(booking.AparmentId));
			}

			return apartments.Select(a => new ApartmentResponse
			{
				Address = new AddressResponse
				{
					City = a.Address.City,
					Country = a.Address.Country,
					State = a.Address.State,
					Street = a.Address.Street,
					ZipCode = a.Address.ZipCode
				},
				Currency = a.Price.Currency.Code,
				Price = a.Price.Amount,
				Description = a.Description.Value,
				Id = a.Id,
				Name = a.Name.Value
			}).ToList();

		}
	}
}
