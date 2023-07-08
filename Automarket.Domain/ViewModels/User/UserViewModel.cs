using System;
using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.ViewModels.User
{
	public class UserViewModel
	{
		[Display(Name = "Id")]
		public long Id { get; set; }

		[Required(ErrorMessage = "Specify the role")]
		[Display(Name = "Role")]
		public string? Role { get; set; }

		[Required(ErrorMessage = "Specify the name")]
		[Display(Name = "Login")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Specify the password")]
		[Display(Name = "Password")]
		public string? Password { get; set; }
	}
}

