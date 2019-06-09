namespace System
{
    public static class DateTimeExtensions
    {
        public static string ToAwsDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
