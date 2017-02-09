namespace NUnit.TestResult.Viewer.Processor.Element
{
    using NUnit.TestResult.Viewer.Processor.Element.Generics;
    using System.Xml.Linq;

    public class TestCaseFailureElement
    {
		internal TestCaseFailureElement(XContainer element)
        {
            this.Message = element.Element(Consts.ELEMENT_NAME_TEST_CASE_FAILURE_MESSAGE)?.Value;
            this.StackTrace = element.Element(Consts.ELEMENT_NAME_TEST_CASE_FAILURE_STACK_TRACE)?.Value;
        }

        public string Message { get; }

        public string StackTrace { get; }
    }
}