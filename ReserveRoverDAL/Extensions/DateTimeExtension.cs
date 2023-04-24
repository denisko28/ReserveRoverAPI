namespace ReserveRoverDAL.Extensions;

public static class DateTimeExtension
{
    public static DateTime FromDateOnlyTimeOnly(this DateTime dt, DateOnly dateOnly, TimeOnly timeOnly)
    {
        return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day, timeOnly.Hour, timeOnly.Minute,
            timeOnly.Second);
    }
}