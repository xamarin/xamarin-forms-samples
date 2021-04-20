using NUnit.Framework;
using System;
using ConceptDevelopment.Net.Cryptography;
using Solitaire;

namespace soltest
{
	/// <summary>
	/// Tests are taken from the author's official website
	/// https://www.schneier.com/code/sol-test.txt
	/// </summary>
	[TestFixture ()]
	public class EncryptionTests
	{
		static string TestKeyText (string key, string text)
		{
			var ps = new PontifexSolitaire (key);
			var output = ps.Encrypt (text).Pad5 ();
			return output;
		}

		[Test ()]
		public void TestKey_nullkey ()
		{
			var output = TestKeyText ("", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("EXKYI ZSGEH UNTIQ", output);
		}

		[Test ()]
		public void TestKey_f ()
		{
			var output = TestKeyText ("f", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("XYIUQ BMHKK JBEGY", output);
		}

		[Test ()]
		public void TestKey_fo ()
		{
			var output = TestKeyText ("fo", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("TUJYM BERLG XNDIW", output);
		}

		[Test ()]
		public void TestKey_foo ()
		{
			var output = TestKeyText ("foo", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("ITHZU JIWGR FARMW", output);
		}

		[Test ()]
		public void TestKey_a ()
		{
			var output = TestKeyText ("a", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("XODAL GSCUL IQNSC", output);
		}

		[Test ()]
		public void TestKey_aa ()
		{
			var output = TestKeyText ("aa", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("OHGWM XXCAI MCIQP", output);
		}

		[Test ()]
		public void TestKey_aaa ()
		{
			var output = TestKeyText ("aaa", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("DCSQY HBQZN GDRUT", output);
		}

		[Test ()]
		public void TestKey_b ()
		{
			var output = TestKeyText ("b", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("XQEEM OITLZ VDSQS", output);
		}

		[Test ()]
		public void TestKey_bc ()
		{
			var output = TestKeyText ("bc", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("QNGRK QIHCL GWSCE", output);
		}

		[Test ()]
		public void TestKey_bcd ()
		{
			var output = TestKeyText ("bcd", "AAAAAAAAAAAAAAA");
			Assert.AreEqual("FMUBY BMAXH NQXCJ", output);
		}

		[Test ()]
		public void TestKey_cryptonomicon_a ()
		{
			var output = TestKeyText ("cryptonomicon", "AAAAAAAAAAAAAAAAAAAAAAAAA");
			Assert.AreEqual("SUGSR SXSWQ RMXOH IPBFP XARYQ", output);
		}

		[Test ()]
		public void TestKey_cryptonomicon_solitaire ()
		{
			var output = TestKeyText ("cryptonomicon", "SOLITAIRE");
			Assert.AreEqual("KIRAK SFJAN", output);
		}
	}
}

