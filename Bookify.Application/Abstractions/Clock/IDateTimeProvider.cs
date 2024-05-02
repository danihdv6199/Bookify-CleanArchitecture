namespace Bookify.Application.Abstractions.Clock
{
	/*
	 * Recap: This is completely testable, I can mock it and provide the date and time that I need
	 */
	public interface IDateTimeProvider
	{
		DateTime UtcNow { get; }
	}
}
