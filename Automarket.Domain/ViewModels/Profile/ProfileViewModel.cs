using System;
using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.ViewModels.Profile
{
	public class ProfileViewModel
	{
		public long Id { get; set; }

		[Required(ErrorMessage = "Specify the age")]
		[Range(0, 150, ErrorMessage = "The age range should be from 0 to 150")]
		public short Age { get; set; }

		[Required(ErrorMessage = "Specify the Address")]
		[MinLength(5, ErrorMessage = "The minimum length must be more than 5 characters")]
		[MaxLength(200, ErrorMessage = "The maximum length must be less than 200 characters")]
		public string? Address { get; set; }

		[Required(ErrorMessage = "Specify the Name")]
		public string? UserName { get; set; }
	}
}

