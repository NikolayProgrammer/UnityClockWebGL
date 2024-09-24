using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clock base class
/// </summary>
public class Clock : MonoBehaviour, IToggleable
{
    /// <summary>
    /// Clock toggled (bool isToggle)
    /// </summary>
    public event Action Toggle_Event;

    /// <summary>
    /// Clock is working or will work on enable
    /// </summary>
    public bool isToggle { get; protected set; }

    /// <summary>
    /// Clock elements (arrows, text-display, etc.)
    /// </summary>
    [SerializeField] protected List<ClockElement> elements = new List<ClockElement>();

    public DateTime currentClockDateTime { get; protected set; }
    protected DateTime startDateTime;
    protected double startDateTimeSetDelay;

    /// <summary>
    /// Clock is working without stopping or disabling since last SetDateTime()
    /// </summary>
    public bool isSynchronized { get; protected set; }

    public virtual void ToggleClock()
    {
        if (isToggle)
        {
            StopClock();
            return;
        }
        StartClock();
    }

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

    public virtual void StopClock()
    {
        if (isToggle)
        {
            isToggle = false;
            isSynchronized = false;
            Toggle_Event?.Invoke();
        }
    }

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