using Bookify.Application.Exceptions;
using Bookify.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure
{
	public sealed class ApplicationDbContext : DbContext, IUnitOfWork
	{
		private readonly IPublisher _publisher;

		public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
			: base(options)
		{
			_publisher = publisher;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("bookify");

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			/*
			 * Recap: (Outbox pattern) In the case of a domain event handler failure, the whole transaction with the savechanges failed
			 */
			try
			{
				var result = await base.SaveChangesAsync(cancellationToken);

				await PublishDomainEventsAsync();

				return result;
			}
			catch (DbUpdateConcurrencyException ex)
			{
				throw new ConcurrencyException("Concurrency exception ocurred", ex);
			}

		}

		/*
		 * Recap: publish all domains event of the entities that added before
		 */
		public async Task PublishDomainEventsAsync()
		{
			var domainEvents = ChangeTracker
				.Entries<Entity>()
				.Select(entry => entry.Entity)
				.SelectMany(entity =>
				{
					var domainEvents = entity.GetDomainEvents();
					entity.ClearDomainEvents();
					return domainEvents;
				})
				.ToList();
			foreach (var domainEvent in domainEvents)
			{
				await _publisher.Publish(domainEvent);
			}
		}
	}
}
