namespace NUnit.TestResult.Viewer.Processor.Extension
{
    using System;

    public static class DateTimeExtension
    {
        public static DateTime ToLocalUtc(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.Local);
        }
    }
}