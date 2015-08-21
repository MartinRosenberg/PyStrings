using NUnit.Framework;

namespace PyStrings.Test
{
	[TestFixture]
	public class PyStringsTests
	{
		[Test]
		public void PosMinNullMaxNegStep()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[2, null, -1], Is.EqualTo("row"));
		}

		[Test]
		public void NegMinNullMaxPosStep()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[-2, null, 1], Is.EqualTo("ds"));
		}

		[Test]
		public void Pos0Index()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[0], Is.EqualTo("w"));
		}

		[Test]
		public void PosIndex()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[4], Is.EqualTo("s"));
		}

		[Test]
		public void NegIndex()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[-5], Is.EqualTo("w"));
		}

		[Test]
		public void Neg1Index()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[-1], Is.EqualTo("s"));
		}

		[Test]
		public void LowPosMinHighPosMax()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[1, 3], Is.EqualTo("or"));
		}

		[Test]
		public void NegMinNullMax()
		{
			PyString ps = new PyString("words");
			Assert.That(ps[-4, null], Is.EqualTo("ords"));
		}

		[Test]
		public void PosMinNullMaxPosStep()
		{
			PyString ps = new PyString("swords");
			Assert.That(ps[1, null, 2], Is.EqualTo("wrs"));
		}

		[Test]
		public void NegMinNullMaxNegStep()
		{
			PyString ps = new PyString("swords");
			Assert.That(ps[-3, null, -1], Is.EqualTo("rows"));
		}

		[Test]
		public void HighPosMinLowPosMaxNegStep()
		{
			PyString ps = new PyString("swords");
			Assert.That(ps[5, 1, -2], Is.EqualTo("sr"));
		}
	}
}
