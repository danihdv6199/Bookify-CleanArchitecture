using Bookify.Application.Abstractions.Clock;

namespace Bookify.Infrastructure.Clock
{
	//Se hace para los text, asi podemos mockear facilmente fechas
	internal sealed class DateTimeProvider : IDateTimeProvider
	{
		public DateTime UtcNow => DateTime.UtcNow;
	}
}
