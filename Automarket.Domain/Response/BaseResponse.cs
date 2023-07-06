using System;
using Automarket.Domain.Enum;

namespace Automarket.Domain.Response
{
	public class BaseResponse
	{
		public string? Description { get; set; } // If an error occurs

		public StatusCode StatusCode { get; set; } // Error code
    }
}

