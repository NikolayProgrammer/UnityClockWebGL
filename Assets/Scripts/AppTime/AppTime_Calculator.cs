using System;
using UnityEngine;

/// <summary>
/// Calculate global app time
/// </summary>
public class AppTime_Calculator
{
    private DateTime setAppDateTime;
    private double setAppDateTimeDelay;

    public void SetAppDateTime(DateTime dateTime)
    {
        setAppDateTime = dateTime;
        setAppDateTimeDelay = Time.realtimeSinceStartupAsDouble;
    }

    public DateTime GetActualAppDateTime()
    {
        return new
            DateTime(setAppDateTime.Ticks + TimeSpan.FromSeconds(Time.realtimeSinceStartupAsDouble - setAppDateTimeDelay).Ticks);
    }
}
