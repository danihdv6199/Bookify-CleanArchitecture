using Bookify.Domain.Abstractions;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Apartments;

/*
 * Recap: If I dont't intend to inherit it, I put sealed
 * 
 * Recap: The problem with primitive types is that they convey no meaning, for I create a Value Object
 * When I create a Value Object I create a record because its support structural equality and immutability
 * 
 * Recap: I put  private set, because I don`t want that the values inside of the entities to be changeable outside of the scope of the entity
 */

public sealed class Apartment : Entity
{
	public Apartment(
		Guid id,
		Name name,
		Description description,
		Address address,
		Money price,
		Money cleaningFee,
		List<Amenity> amenities)
		: base(id)
	{
		Name = name;
		Description = description;
		Address = address;
		Price = price;
		CleaningFee = cleaningFee;
		Amenities = amenities;
	}
	private Apartment() { }
	public Name Name { get; private set; }
	public Description Description { get; private set; }
	public Address Address { get; private set; }
	public Money Price { get; private set; }
	public Money CleaningFee { get; private set; }
	/*
	 * Recap: With internal, only can set the property in the domain layer
	 */
	public DateTime? LastBookedOnUtc { get; internal set; }
	public List<Amenity> Amenities { get; private set; } = new List<Amenity>();
}
