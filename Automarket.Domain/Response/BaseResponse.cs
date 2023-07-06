using System;
using Automarket.Domain.Enum;

namespace Automarket.Domain.Response
{
	public class BaseResponse<T> : IBaseResponse<T>
	{
		public string? Description { get; set; } // If an error occurs

		public StatusCode StatusCode { get; set; } // Error code

		public T? Data { get; set; }
    }

	public interface IBaseResponse<T>
	{
		T? Data { get; set; }
	}
}

