namespace NUnit.TestResult.Viewer.Processor
{
    using NUnit.TestResult.Viewer.Processor.Generics;
    using System.Xml.Linq;

    public class TestCaseFailureElement
    {
        public TestCaseFailureElement(XContainer element)
        {
            this.Message = element.Element(Consts.ELEMENT_NAME_TEST_CASE_FAILURE_MESSAGE)?.Value;
            this.StackTrace = element.Element(Consts.ELEMENT_NAME_TEST_CASE_FAILURE_STACK_TRACE)?.Value;
        }

        public string Message { get; }

        public string StackTrace { get; }
    }
}