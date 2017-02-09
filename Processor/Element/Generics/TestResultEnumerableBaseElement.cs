namespace NUnit.TestResult.Viewer.Processor.Element.Generics
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Xml.Linq;

	public abstract class TestResultEnumerableBaseElement : TestResultBaseElement, IEnumerable<TestResultBaseElement>
	{
		protected TestResultEnumerableBaseElement(XElement element)
			: base(element)
		{
		}

		public abstract IEnumerator<TestResultBaseElement> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}

}