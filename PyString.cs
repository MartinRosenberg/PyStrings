using System;
using System.Text;

namespace PyString
{
	public class PyString
	{
		// Values
		public static string Value { get; private set; }

		// Constructor
		public PyString(string value)
		{
			Value = value;
		}

		// Implicit conversions
		public static implicit operator string(PyString value)
			=> value.ToString();

		public static implicit operator PyString(string value)
			=> new PyString(value);

		// Convert Python indices to C# ones
		private int PythonizeIndex(int index)
			=> index < 0 
				? Value.Length + index
				: index;

		// Python substring, part 1
		public string this[int index] 
			=> index == -1
				? this[index, null]
				: this[index, index + 1];

		// Python substring, part 2
		public string this[int? nMin = null, int? nMax = null, int? nStep = null]
		{
			get
			{
				// Default arguments + index conversion
				int step = nStep ?? 1;
				int min = nMin.HasValue ? PythonizeIndex(nMin.Value) : 0;
				int max = nMax.HasValue ? PythonizeIndex(nMax.Value) : (step < 0 ? -1 : Value.Length);

				// Rebuild string - exception cases
				if (step == 0)
				{
					// Special case 1 - a 0 step size isn't allowed, so throw an exception
					throw new ArgumentOutOfRangeException(nameof(step), "Step size cannot be zero.");
				}
				if (Math.Sign(step) != Math.Sign(max - min))
				{
					// Special case 2 - step and bounds point in opposite directions
					throw new ArgumentOutOfRangeException(nameof(step), "Step size is incorrectly signed for the given bounds values.");
				}

				// Rebuild string - general case
				StringBuilder result = new StringBuilder();
				int cur = min;
				while (step > 0 ? cur < max : cur > max)
				{
					result.Append(Value[cur]);
					cur += step;
				}

				// Done!
				return result.ToString();
			}
		}
	}
}