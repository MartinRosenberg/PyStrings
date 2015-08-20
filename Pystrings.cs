using System;
using System.Text;


// Code by Ace "ace-n" Nassri
// Licensed under the MIT license
// This has only been lightly tested, so use with care...
namespace String {
    public class PyString {

        // Values
        private static string myValue;

        // Constructor
        public PyString(string s) {
            myValue = s;
        }

        // Implicit conversions
        public static implicit operator string(PyString s) {
            return s.ToString();
        }
        public static implicit operator PyString(string s) {
            return new PyString(s);
        }

        // Convert Python indices to C# ones
        private int pyIndex(int idx) {
            return idx < 0 ? myValue.Length + idx : idx;
        }

        // Python substring, part 1
        public string this[int a] {
            get {
                return this[a, a + (a<=0 ? 1:-1)];
            }
        }

        // Python substring, part 2
        public string this[Nullable<int> nMin = null, Nullable<int> nMax = null, Nullable<int> nStep = null] {
            get {

                // Default arguments + index conversion
                int step = nStep.HasValue ? nStep.Value : 1;
                int min = nMin.HasValue ? pyIndex(nMin.Value) : 0;
                int max = nMax.HasValue ? pyIndex(nMax.Value) : (step < 0 ? -1 : myValue.Length);

                // Rebuild string - exception cases
                if (step == 0) {
                    // Special case 1 - a 0 step size isn't allowed, so throw an exception
                    throw new ArgumentOutOfRangeException("Step size cannot be zero.");
                } else if (Math.Sign(step) != Math.Sign(max - min)) {
                    // Special case 2 - step and bounds point in opposite directions
                    throw new ArgumentOutOfRangeException("Step size is incorrectly signed for the given bounds values.");
                }
                
                // Rebuild string - general case
                StringBuilder result = new StringBuilder();
                int cur = min;
                while (step > 0 ? cur < max : cur > max) {
                    result.Append(myValue[cur]);
                    cur += step;
                }

                // Done!
                return result.ToString();
            }
        }
    }
}
