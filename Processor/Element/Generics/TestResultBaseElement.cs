namespace NUnit.TestResult.Viewer.Processor.Element.Generics
{
	using NUnit.TestResult.Viewer.Processor.Extension;
	using System;
	using System.Xml.Linq;
	using NUnit.TestResult.Viewer.Processor.Enum;

	public abstract class TestResultBaseElement
	{
		private const string ATTR_NAME_ASSERTS = "asserts";

		private const string ATTR_NAME_END_TIME = "end-time";

		private const string ATTR_NAME_ID = "id";

		private const string ATTR_NAME_RESULT = "result";

		private const string ATTR_NAME_START_TIME = "start-time";

		protected TestResultBaseElement(XElement element)
		{
			DoCheck(this, element);

			this.Id = element.GetAttrValue<int>(ATTR_NAME_ID);
			this.Asserts = element.GetAttrValue<int>(ATTR_NAME_ASSERTS);
			this.Result = element.GetAttrValue<ETestResultType>(ATTR_NAME_RESULT);
			this.StartTime = element.GetAttrValue<DateTime>(ATTR_NAME_START_TIME).ToLocalUtc();
			this.EndTime = element.GetAttrValue<DateTime>(ATTR_NAME_END_TIME).ToLocalUtc();
			this.Duration = this.EndTime - this.StartTime;
		}

		public int Asserts { get; }

		public TimeSpan Duration { get; }

		public DateTime EndTime { get; }

		public int Id { get; }

		public ETestResultType Result { get; }

		public DateTime StartTime { get; }

		protected abstract void CheckIfElementIsValidForClassType(XElement element);

		private static void DoCheck(TestResultBaseElement baseElement, XElement element)
		{
			baseElement.CheckIfElementIsValidForClassType(element);
		}
	}
}