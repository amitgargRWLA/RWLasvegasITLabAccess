using System;

namespace ITLabAccess.Service
{
    public static class ServiceUtility
    {
     
         public static DateTime GetPacificStandardTime()
    {
        var utc = DateTime.UtcNow.AddDays(-1);
        TimeZoneInfo pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        var pacificTime = TimeZoneInfo.ConvertTimeFromUtc(utc, pacificZone);
        return pacificTime;
    }
       
    }
}