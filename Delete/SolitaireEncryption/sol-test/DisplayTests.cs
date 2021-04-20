using System;
using NUnit.Framework;
using Solitaire;

namespace soltest
{
	[TestFixture ()]
	public class DisplayTests
	{
		[Test ()]
		public void TestPad5 ()
		{
			Assert.AreEqual("XYIUQ BMHKK JBEGY", "XYIUQBMHKKJBEGY".Pad5());
		}

		[Test ()]
		public void TestPad5_short ()
		{
			// throws because not a multiple of 5 characters
			Assert.AreEqual("HELOX", "HELO".Pad5()); 
		}

		[Test ()]
		public void TestPad5_medium ()
		{
			// throws because not a multiple of 5 characters
			Assert.AreEqual("SOLIT AIREX", "SOLITAIRE".Pad5()); 
		}
	}
}

