namespace NUnit.TestResult.Viewer.Processor
{
	using System.Diagnostics.Contracts;
	using System.IO;
	using System.Xml.Linq;
	using NUnit.TestResult.Viewer.Processor.Element;

	public static class TestResultProcessor
	{
		public static TestRunElement Load(string testResultFileName)
		{
			if (!File.Exists(testResultFileName))
			{
				throw new FileNotFoundException("Cannot locate the file.", testResultFileName); 
			}

			return new TestRunElement(XDocument.Load(testResultFileName).Root);
		}
	}
}
