﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class Create_Database : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.EnsureSchema(
				name: "bookify");

			migrationBuilder.CreateTable(
				name: "apartments",
				schema: "bookify",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
					Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Price_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CleaningFee_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					CleaningFee_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastBookedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
					Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_apartments", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "users",
				schema: "bookify",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					LastName = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
					Email = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "bookings",
				schema: "bookify",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Duration_Start = table.Column<DateOnly>(type: "date", nullable: false),
					Duration_End = table.Column<DateOnly>(type: "date", nullable: false),
					PriceForPeriod_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					PriceForPeriod_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CleaningFee_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					CleaningFee_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
					AmenitiesUpCharge_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					AmenitiesUpCharge_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
					TotalPrice_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					TotalPrice_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false),
					CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
					RejectedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
					ConfirmedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
					CompletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
					CancelledOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
					AparmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_bookings", x => x.Id);
					table.ForeignKey(
						name: "FK_bookings_apartments_AparmentId",
						column: x => x.AparmentId,
						principalSchema: "bookify",
						principalTable: "apartments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_bookings_users_UserId",
						column: x => x.UserId,
						principalSchema: "bookify",
						principalTable: "users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "reviews",
				schema: "bookify",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Rating = table.Column<int>(type: "int", nullable: false),
					Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_reviews", x => x.Id);
					table.ForeignKey(
						name: "FK_reviews_apartments_ApartmentId",
						column: x => x.ApartmentId,
						principalSchema: "bookify",
						principalTable: "apartments",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_reviews_bookings_BookingId",
						column: x => x.BookingId,
						principalSchema: "bookify",
						principalTable: "bookings",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_reviews_users_UserId",
						column: x => x.UserId,
						principalSchema: "bookify",
						principalTable: "users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_bookings_AparmentId",
				schema: "bookify",
				table: "bookings",
				column: "AparmentId");

			migrationBuilder.CreateIndex(
				name: "IX_bookings_UserId",
				schema: "bookify",
				table: "bookings",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_reviews_ApartmentId",
				schema: "bookify",
				table: "reviews",
				column: "ApartmentId");

			migrationBuilder.CreateIndex(
				name: "IX_reviews_BookingId",
				schema: "bookify",
				table: "reviews",
				column: "BookingId");

			migrationBuilder.CreateIndex(
				name: "IX_reviews_UserId",
				schema: "bookify",
				table: "reviews",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_users_Email",
				schema: "bookify",
				table: "users",
				column: "Email",
				unique: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "reviews",
				schema: "bookify");

			migrationBuilder.DropTable(
				name: "bookings",
				schema: "bookify");

			migrationBuilder.DropTable(
				name: "apartments",
				schema: "bookify");

			migrationBuilder.DropTable(
				name: "users",
				schema: "bookify");
		}
	}
}
