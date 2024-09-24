using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Редактор времени на часах
/// </summary>
public class Clock_SetTime_Editor : MonoBehaviour
{
    /// <summary>
    /// Часы, с которыми мы работаем
    /// </summary>
    [SerializeField] Clock clock;

    /// <summary>
    /// Время на часах ДО редактирования
    /// </summary>
    private DateTime clockDateTimeBeforeEdit;

    /// <summary>
    /// Были ли часы включены ДО редактирования
    /// </summary>
    private bool clockIsToggleBeforeEdit;

    public void StartEdit()
    {
        clockDateTimeBeforeEdit = clock.currentClockDateTime;
        clockIsToggleBeforeEdit = clock.isToggle;
        clock.StopClock();
    }

    public void ApplyEdit()
    {
        if (clockIsToggleBeforeEdit)
        {
            clock.StartClock();
        }
    }

    public void CancelEdit()
    {
        if (clockIsToggleBeforeEdit)
        {
            clock.SetDateTimeAndStartClock(clockDateTimeBeforeEdit);
        }
        else
        {
            clock.SetDateTime(clockDateTimeBeforeEdit);
        }
    }
}
