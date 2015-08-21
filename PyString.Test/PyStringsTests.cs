using NUnit.Framework;
using static System.Console;

namespace PyStrings.Test
{
	[TestFixture]
	public class PyStringsTests
	{
		[Test]
		public static void Pos0Idx()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[0], Is.EqualTo("w"));
		}

		[Test]
		public static void PosIdx()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[4], Is.EqualTo("s"));
		}

		[Test]
		public static void NegIdx()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[-5], Is.EqualTo("w"));
		}

		[Test]
		public static void Neg1Idx()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[-1], Is.EqualTo("s"));
		}

		[Test]
		public static void LowPosMinHighPosMax()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[1, 3], Is.EqualTo("or"));
		}

		[Test]
		public static void NegMinNullMax()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[-4, null], Is.EqualTo("ords"));
		}

		[Test]
		public static void PosMinNullMaxPosStep()
		{
			PyString ps = new PyString("swords");
			Assert.That(ps[1, null, 2], Is.EqualTo("wrs"));
		}

		[Test]
		public static void NegMinNullMaxNegStep()
		{
			PyString ps = new PyString("swords");
			Assert.That(ps[-3, null, -1], Is.EqualTo("rows"));
		}

		[Test]
		public static void HighPosMinLowPosMaxNegStep()
		{
			PyString ps = new PyString("swords");
			Assert.That(ps[5, 1, -2], Is.EqualTo("sr"));
		}
	}
}
