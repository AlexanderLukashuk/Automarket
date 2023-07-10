using System;
namespace Automarket.Domain.Entity
{
	public class Profile
	{
		public long Id { get; set; }

		public short Age { get; set; }

		public string? Address { get; set; }

		public long UserId { get; set; }

		public User? Usser { get; set; }
	}
}

