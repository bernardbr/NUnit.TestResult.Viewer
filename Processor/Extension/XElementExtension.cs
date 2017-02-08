namespace NUnit.TestResult.Viewer.Processor.Extension
{
    using System;
    using System.Xml.Linq;

    public static class XElementExtension
    {
        public static T GetAttrValue<T>(this XElement element, string attrName)
        {
            var attr = element.Attribute(attrName);
            if (attr == null)
            {
                return default(T);
            }

            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), attr.Value);
            }

            return (T)Convert.ChangeType(attr.Value, typeof(T));
        }
    }
}