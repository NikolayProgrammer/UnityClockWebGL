using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Базовый класс часов
/// </summary>
public class Clock : MonoBehaviour, IToggleable
{
    /// <summary>
    /// Часы включились/выключились (bool isToggle)
    /// </summary>
    public event Action Toggle_Event;

    /// <summary>
    /// Часы работают либо будут работать при включении объекта
    /// </summary>
    public bool isToggle { get; protected set; }

    /// <summary>
    /// Элементы часов (стрелки, дисплей и пр.)
    /// </summary>
    [SerializeField] protected List<ClockElement> elements = new List<ClockElement>();

    public DateTime currentClockDateTime { get; protected set; }
    protected DateTime startDateTime;
    protected double startDateTimeSetDelay;

    /// <summary>
    /// Часы идут не останавливаясь/выключаясь с последнего SetDateTime()
    /// </summary>
    public bool isSynchronized { get; protected set; }

    /// <summary>
    /// Вкл/выкл часы 
    /// </summary>
    public virtual void ToggleClock()
    {
        if (isToggle)
        {
            StopClock();
            return;
        }
        StartClock();
    }

    /// <summary>
    /// Возобновить ход часов
    /// </summary>
    public virtual void StartClock()
    {
        if (!isToggle)
        {
            startDateTime = currentClockDateTime;
            startDateTimeSetDelay = Time.realtimeSinceStartupAsDouble;
            isToggle = true;
            StartCoroutine(Work_COR());
            Toggle_Event?.Invoke();
        }
    }

    /// <summary>
    /// Остановить ход часов
    /// </summary>
    public virtual void StopClock()
    {
        if (isToggle)
        {
            isToggle = false;
            isSynchronized = false;
            Toggle_Event?.Invoke();
        }
    }

    /// <summary>
    /// Задать часам начало отсчёта
    /// </summary>
    public virtual void SetDateTime(DateTime dateTime)
    {
        startDateTime = dateTime;
        currentClockDateTime = dateTime;
        startDateTimeSetDelay = Time.realtimeSinceStartupAsDouble;
        if (isToggle)
        {
            isSynchronized = true;
        }
        UpdateElements();
    }

    /// <summary>
    /// Запустить часы с заданного времени
    /// </summary>
    public virtual void SetDateTimeAndStartClock(DateTime dateTime)
    {
        StartClock();
        SetDateTime(dateTime);
    }

    protected virtual void UpdateCurrentDateTime()
    {
        currentClockDateTime =
            new(startDateTime.Ticks + TimeSpan.FromSeconds(Time.realtimeSinceStartupAsDouble - startDateTimeSetDelay).Ticks);
    }

    private void OnDisable()
    {
        StopClock();
    }

    protected virtual void UpdateElements()
    {
        foreach (var element in elements)
        {
            element.UpdateElement(currentClockDateTime);
        }
    }

    protected virtual IEnumerator Work_COR()
    {
        while (isToggle)
        {
            UpdateCurrentDateTime();
            UpdateElements();
            yield return null;
        }
    }
}