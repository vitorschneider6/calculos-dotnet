namespace Shared.ExtensionMethods;

public static class DateTimeExtensions
{
    public static DateTime GetBrazilianTimeStamp(this DateTime dateTime)
    {
        var brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        return TimeZoneInfo.ConvertTime(dateTime, brazilTimeZone);
    }
}