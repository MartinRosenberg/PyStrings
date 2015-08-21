using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyStrings
{
	public static class StringExtensionMethods
	{
		public static PyString ToPyString(this string value)
		{
			return new PyString(value);
		}
	}
}
