﻿using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;
using Bookify.Infrastructure.Clock;
using Bookify.Infrastructure.Email;
using Bookify.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastucture(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddTransient<IDateTimeProvider, DateTimeProvider>();
			services.AddTransient<IEmailService, EmailService>();

			var connectionString =
				configuration.GetConnectionString("DefaultConnection")
				?? throw new ArgumentNullException(nameof(configuration));

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
				options.EnableSensitiveDataLogging();
			},
			ServiceLifetime.Scoped
			);

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IApartmentRepository, ApartmentRepository>();
			services.AddScoped<IBookingRepository, BookingRepository>();
			services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

			return services;
		}
	}
}
