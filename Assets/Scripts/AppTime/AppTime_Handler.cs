using System;
using UnityEngine;

/// <summary>
/// Расчёт актуального глобального времени
/// </summary>
public class AppTime_Handler
{
    private DateTime setAppDateTime;
    private double setAppDateTimeDelay;

    /// <summary>
    /// Установить глобальное временя
    /// </summary>
    public void SetAppDateTime(DateTime dateTime)
    {
        setAppDateTime = dateTime;
        setAppDateTimeDelay = Time.realtimeSinceStartupAsDouble;
    }

    /// <summary>
    /// Получить глобальное время
    /// </summary>
    public DateTime GetActualAppDateTime()
    {
        return new
            DateTime(setAppDateTime.Ticks + TimeSpan.FromSeconds(Time.realtimeSinceStartupAsDouble - setAppDateTimeDelay).Ticks);
    }

    /// <summary>
    /// Привести экземпляр DateTime к глобальному времени
    /// </summary>
    public void ChangeDateTimeToAppDateTime(ref DateTime dateTime)
    {
        dateTime = GetActualAppDateTime();
    }
}
