namespace NUnit.TestResult.Viewer.Processor.Generics
{
    using NUnit.TestResult.Viewer.Processor.Extension;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public abstract class TestResultBaseElement : IEnumerable<TestResultBaseElement>
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
            this.Result = element.GetAttrValue<string>(ATTR_NAME_RESULT);
            this.StartTime = element.GetAttrValue<DateTime>(ATTR_NAME_START_TIME).ToLocalUtc();
            this.EndTime = element.GetAttrValue<DateTime>(ATTR_NAME_END_TIME).ToLocalUtc();
            this.Duration = this.EndTime - this.StartTime;
        }

        public int Asserts { get; }

        public TimeSpan Duration { get; }

        public DateTime EndTime { get; }

        public int Id { get; }

        public string Result { get; }

        public DateTime StartTime { get; }

        protected abstract void CheckIfElementIsValidForClassType(XElement element);

        private static void DoCheck(TestResultBaseElement baseElement, XElement element)
        {
            baseElement.CheckIfElementIsValidForClassType(element);
        }

        public abstract IEnumerator<TestResultBaseElement> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}