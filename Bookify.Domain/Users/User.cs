using Bookify.Domain.Abstractions;
using Bookify.Domain.Users.Events;

namespace Bookify.Domain.Users
{
	public sealed class User : Entity
	{
		private User() { }

		private User(
			Guid id,
			FirstName firstName,
			LastName lastName,
			Email email)
			: base(id)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}

		public FirstName FirstName { get; private set; }
		public LastName LastName { get; private set; }
		public Email Email { get; private set; }
		/*
		 * 
		 * Factory Method (Static Factory):
		 * I am hiding the constructor that has othe implementations details that I don't want to expose outside of the entity
		 * Be able to introduce some side effects inside of the factory method that dont naturally belong inside of a contructor (domain events)
		 * 
		 */
		public static User Create(FirstName firstName, LastName lastName, Email email)
		{
			var user = new User(Guid.NewGuid(), firstName, lastName, email);
			/*
			 * Recap: Publish (Add) the DomainEvent, now someone can subscribe to this event and execute some behaviour asynchronously
			 */
			user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
			return user;
		}
	}

}
