using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Automarket.Domain.Extensions
{
	public static class EnumExtension
	{
		public static string GetDisplayName(this System.Enum enumValue)
		{
			//return enumValue.GetType()
			//	.GetMember(enumValue.ToString())
			//	.First()
			//	.GetCustomAttributes<DisplayAttribute>()
   //             ?.GetName() ?? "Indefinite";

			var memberInfo = enumValue.GetType()
				.GetMember(enumValue.ToString())
				.First();

			if (memberInfo != null)
			{
				var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
				if (displayAttribute != null)
					return displayAttribute.Name;
			}

			return "Indefinite";
        }
	}
}

