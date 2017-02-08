namespace NUnit.TestResult.Viewer.Processor
{
    using NUnit.TestResult.Viewer.Processor.Enum;
    using NUnit.TestResult.Viewer.Processor.Extension;
    using NUnit.TestResult.Viewer.Processor.Generics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class TestSuiteElement : TestResultBaseElement
    {
        private readonly List<TestCaseElement> testCaseElements;

        private readonly List<TestSuiteElement> testSuiteElements;

        public TestSuiteElement(XElement element)
            : base(element)
        {
            this.TestCaseCount = element.GetAttrValue<int>(Consts.ATTR_NAME_TEST_CASE_COUNT);
            this.Total = element.GetAttrValue<int>(Consts.ATTR_NAME_TOTAL);
            this.Passed = element.GetAttrValue<int>(Consts.ATTR_NAME_PASSED);
            this.Failed = element.GetAttrValue<int>(Consts.ATTR_NAME_FAILED);
            this.Inconclusive = element.GetAttrValue<int>(Consts.ATTR_NAME_INCONCLUSIVE);
            this.Skipped = element.GetAttrValue<int>(Consts.ATTR_NAME_SKIPPED);

            this.Warnings = element.GetAttrValue<int>(Consts.ATTR_NAME_WARNINGS);
            this.Type = element.GetAttrValue<ETestSuiteType>(Consts.ATTR_NAME_TYPE);
            this.Site = element.GetAttrValue<string>(Consts.ATTR_NAME_SITE);

            this.FullName = element.GetAttrValue<string>(Consts.ATTR_NAME_FULL_NAME);
            this.Name = element.GetAttrValue<string>(Consts.ATTR_NAME_NAME);
            this.RunState = element.GetAttrValue<string>(Consts.ATTR_NAME_RUNSTATE);

            this.testSuiteElements = new List<TestSuiteElement>();
            this.testSuiteElements.AddRange(
                element.Elements(Consts.ELEMENT_NAME_TEST_SUITE).Select(e => new TestSuiteElement(e)));

            this.testCaseElements = new List<TestCaseElement>();
            this.testCaseElements.AddRange(
                element.Elements(Consts.ELEMENT_NAME_TEST_CASE).Select(e => new TestCaseElement(e)));
        }

        public int Failed { get; }

        public string FullName { get; }

        public int Inconclusive { get; }

        public string Name { get; }

        public int Passed { get; }

        public string RunState { get; }

        public string Site { get; set; }

        public int Skipped { get; }

        public int TestCaseCount { get; }

        public IReadOnlyList<TestCaseElement> TestCaseElements => this.testCaseElements;

        public IReadOnlyList<TestSuiteElement> TestSuiteElements => this.testSuiteElements;

        public int Total { get; }

        public ETestSuiteType Type { get; }

        public int Warnings { get; }

        protected override void CheckIfElementIsValidForClassType(XElement element)
        {
            if (!element.Name.ToString().Equals(Consts.ELEMENT_NAME_TEST_SUITE))
            {
                throw new ArgumentException(
                    $"The element doesn't represent a {Consts.ELEMENT_NAME_TEST_SUITE}.",
                    nameof(element));
            }
        }

        public override IEnumerator<TestResultBaseElement> GetEnumerator()
        {
            foreach (var testCaseElement in this.testCaseElements)
            {
                yield return testCaseElement;
            }

            foreach (var testSuiteElement in this.testSuiteElements)
            {
                yield return testSuiteElement;
            }
        }
    }
}