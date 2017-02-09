namespace NUnit.TestResult.Viewer.Processor.Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using NUnit.TestResult.Viewer.Processor.Extension;
    using NUnit.TestResult.Viewer.Processor.Element.Generics;

    public class TestCaseElement : TestResultEnumerableBaseElement
    {
        private readonly List<TestCaseFailureElement> failures;

		internal TestCaseElement(XElement element)
            : base(element)
        {
            this.FullName = element.GetAttrValue<string>(Consts.ATTR_NAME_FULL_NAME);
            this.Name = element.GetAttrValue<string>(Consts.ATTR_NAME_NAME);
            this.RunState = element.GetAttrValue<string>(Consts.ATTR_NAME_RUNSTATE);
            this.ClassName = element.GetAttrValue<string>(Consts.ATTR_NAME_CLASSNAME);
            this.MethodName = element.GetAttrValue<string>(Consts.ATTR_NAME_METHODNAME);
            this.Seed = element.GetAttrValue<string>(Consts.ATTR_NAME_SEED);
            this.Label = element.GetAttrValue<string>(Consts.ATTR_NAME_LABEL);
            this.failures = new List<TestCaseFailureElement>();
            this.failures.AddRange(
                element.Elements(Consts.ELEMENT_NAME_TEST_CASE_FAILURE).Select(e => new TestCaseFailureElement(e)));
        }

        public string ClassName { get; }

        public IReadOnlyList<TestCaseFailureElement> Failures => this.failures;

        public string FullName { get; }

        public string Label { get; }

        public string MethodName { get; }

        public string Name { get; }

        public string RunState { get; }

        public string Seed { get; }

        public override IEnumerator<TestResultBaseElement> GetEnumerator()
        {
            return new List<TestResultBaseElement>().GetEnumerator();
        }

        protected override void CheckIfElementIsValidForClassType(XElement element)
        {
            if (!element.Name.ToString().Equals(Consts.ELEMENT_NAME_TEST_CASE))
            {
                throw new ArgumentException(
                    $"The element doesn't represent a {Consts.ELEMENT_NAME_TEST_CASE}.", 
                    nameof(element));
            }
        }
    }
}