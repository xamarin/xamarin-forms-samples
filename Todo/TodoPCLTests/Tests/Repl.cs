using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TodoPCLTests
{
	public class ReplTests : BaseTest
	{
		//Constructor inheriting from BaseTest class
		public ReplTests(Platform platform) : base(platform)
		{
		}


		//override BeforeEastTest method from BaseTest class
		//public override void BeforeEachTest()
		//{
		//	base.BeforeEachTest();
		//}


		[Test]
		public void Repl()
		{
			app.Repl();
		}
	}
}
