using System;
using System.Text;

namespace PyStrings
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

		public PyString(char[] value)
		{
			Value = new string(value);
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
				int step = nStep ?? 1;

				if (step == 0)
				{
					throw new ArgumentOutOfRangeException(nameof(step), "Step size cannot be zero.");
				}
				
				int min = PythonizeIndex(nMin ?? 0);
				int max = nMax.HasValue
					? PythonizeIndex(nMax.Value)
					: step < 0
						? -1
						: Value.Length;

				if (Math.Sign(step) != Math.Sign(max - min))
				{
					throw new ArgumentOutOfRangeException(nameof(step), "Step size is incorrectly signed for the given bounds.");
				}

				StringBuilder result = new StringBuilder();
				for (int i = min; (step > 0 ? i < max : i > max); i += step)
				{
					result.Append(Value[i]);
				}
				
				return result.ToString();
			}
		}

		#endregion Indexers
	}
}