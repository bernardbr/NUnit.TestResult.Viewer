namespace Processor.Test
{
	using System.Diagnostics;
	using System.Linq;
	using NUnit.Framework;
	using NUnit.TestResult.Viewer.Processor;

	[TestFixture]
	public class TestResultProcessorTest
	{
		[Test]
		public void ShouldBeLoadATestResultXml()
		{
			var testRunElement = TestResultProcessor.Load("./Artifacts/TestResult.xml");
			var count = testRunElement.Count();

			Assert.IsNotNull(testRunElement);
			Assert.That(count, Is.GreaterThan(0), "The amount of items should be greater than zero.");
		}
	}
}
