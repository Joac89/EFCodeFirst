using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCommon
{
	public static class Extensions
	{
		/// <summary>
		/// Convierte un objeto de tipo String a DateTime
		/// </summary>
		/// <param name="dateString"></param>
		/// <returns></returns>
		public static DateTime ToDateTime(this string dateString)
		{
			return DateTime.Parse(dateString);
		}

		/// <summary>
		/// Convierte un objeto de tipo DateTime a String con el formato correspondiente a yyyy-MM-dd
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static string ToDateString(this DateTime dateTime)
		{
			return dateTime.ToString("yyy-MM-dd");
		}
	}
}
