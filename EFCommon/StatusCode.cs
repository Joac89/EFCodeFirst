using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCommon
{
	public static class StatusCode
	{
		public static int Ok { get; set; } = 200;
		public static int InternalError { get; set; } = 500;
		public static int ServiceUnavailable { get; set; } = 503;
		public static int NotFound { get; set; } = 404;
	}
}
