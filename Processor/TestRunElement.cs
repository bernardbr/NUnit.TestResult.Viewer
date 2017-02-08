namespace NUnit.TestResult.Viewer.Processor
{
    using NUnit.TestResult.Viewer.Processor.Extension;
    using NUnit.TestResult.Viewer.Processor.Generics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class TestRunElement : TestResultBaseElement
    {
        private readonly List<TestRunElement> testRunElements;

        private readonly List<TestSuiteElement> testSuiteElements;

        public TestRunElement(XElement element)
            : base(element)
        {
            this.TestCaseCount = element.GetAttrValue<int>(Consts.ATTR_NAME_TEST_CASE_COUNT);
            this.Total = element.GetAttrValue<int>(Consts.ATTR_NAME_TOTAL);
            this.Passed = element.GetAttrValue<int>(Consts.ATTR_NAME_PASSED);
            this.Failed = element.GetAttrValue<int>(Consts.ATTR_NAME_FAILED);
            this.Inconclusive = element.GetAttrValue<int>(Consts.ATTR_NAME_INCONCLUSIVE);
            this.Skipped = element.GetAttrValue<int>(Consts.ATTR_NAME_SKIPPED);

            this.testRunElements = new List<TestRunElement>();
            this.testRunElements.AddRange(
                element.Elements(Consts.ELEMENT_NAME_TEST_RUN).Select(e => new TestRunElement(e)));

            this.testSuiteElements = new List<TestSuiteElement>();
            this.testSuiteElements.AddRange(
                element.Elements(Consts.ELEMENT_NAME_TEST_SUITE).Select(e => new TestSuiteElement(e)));
        }

        public int Failed { get; }

        public int Inconclusive { get; }

        public int Passed { get; }

        public int Skipped { get; }

        public int TestCaseCount { get; }

        public IReadOnlyList<TestRunElement> TestRunElements => this.testRunElements;

        public IReadOnlyList<TestSuiteElement> TestSuiteElements => this.testSuiteElements;

        public int Total { get; }

        protected override void CheckIfElementIsValidForClassType(XElement element)
        {
            if (!element.Name.ToString().Equals(Consts.ELEMENT_NAME_TEST_RUN))
            {
                throw new ArgumentException(
                    $"The element doesn't represent a {Consts.ELEMENT_NAME_TEST_RUN}.",
                    nameof(element));
            }
        }

        public override IEnumerator<TestResultBaseElement> GetEnumerator()
        {
            foreach (var testSuiteElement in this.testSuiteElements)
            {
                yield return testSuiteElement;
            }

            foreach (var testRunElement in this.testRunElements)
            {
                yield return testRunElement;
            }
        }
    }
}