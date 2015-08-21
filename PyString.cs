using System;
using System.Text;

namespace PyString
{
	public class PyString
	{
		#region Values
		
		public string Value { get; }

		#endregion Values

		#region Constructors

		public PyString(string value)
		{
			Value = value;
		}

		#endregion Constructors

		#region Implicit conversions

		public static implicit operator string(PyString value)
			=> value.ToString();

		public static implicit operator PyString(string value)
			=> new PyString(value);

		#endregion Implicit conversions

		#region Overrides

		public override string ToString()
			=> Value;

		#endregion Overrides

		#region Helper methods

		private int PythonizeIndex(int index)
			=> index < 0 
				? Value.Length + index
				: index;
		
		#endregion Helper methods
		
		#region Indexers
		
		public string this[int index] 
			=> index == -1
				? this[index, null]
				: this[index, index + 1];

		public string this[int? nMin = null, int? nMax = null, int? nStep = null]
		{
			get
			{
				// Default arguments + index conversion
				int step = nStep ?? 1;
				int min = nMin.HasValue
					? PythonizeIndex(nMin.Value)
					: 0;
				int max = nMax.HasValue
					? PythonizeIndex(nMax.Value)
					: (step < 0 ? -1 : Value.Length);

				// Rebuild string - exception cases
				if (step == 0)
				{
					throw new ArgumentOutOfRangeException(nameof(step), "Step size cannot be zero.");
				}
				if (Math.Sign(step) != Math.Sign(max - min))
				{
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

		#endregion Indexers
	}
}