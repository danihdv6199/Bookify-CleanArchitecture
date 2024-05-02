using Bookify.Api.Extensions;
using Bookify.Application;
using Bookify.Infrastructure;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastucture(builder.Configuration);

var app = builder.Build();
app.UseRequestLocalization(new RequestLocalizationOptions()
{
	DefaultRequestCulture = new RequestCulture("en-US"),
	SupportedCultures = new[]{
		new CultureInfo("en-US")
	},
	FallBackToParentCultures = false,

});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseCustomExeptionHandler();
//app.UseAuthorization();

app.MapControllers();

app.Run();
