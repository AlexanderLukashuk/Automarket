using System;
using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.ViewModels.Account
{
	public class ChangePasswordViewModel
	{
		[Required(ErrorMessage = "Specify the Name")]
		public string? UserName { get; set; }

		[Required(ErrorMessage = "Enter the password")]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		[MinLength(5, ErrorMessage = "The password must be greater than or equal to 5 characters")]
		public string? NewPassword { get; set; }
	}
}

