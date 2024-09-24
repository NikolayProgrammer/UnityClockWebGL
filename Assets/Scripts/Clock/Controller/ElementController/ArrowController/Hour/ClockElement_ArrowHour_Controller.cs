using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер часовой стрелки (не работает!)
/// </summary>
public class ClockElement_Arrow_Hour_HandController : ClockElement_Arrow_Controller
{
    [SerializeField] protected ClockElement_Arrow_Hour hourArrow;

    private void Start()
    {
        SetArrow(hourArrow);
    }

    public void SetArrow(ClockElement_Arrow_Hour arrow)
    {
        if (arrow != null)
        {
            arrowTransform = arrow.transform;
        }
    }

    private void OnEnable()
    {
        if(clock != null)
        {
            past_hour = clock.currentClockDateTime.Hour;
        }
    }

    // Кеширование переменных
    private int hour;
    private int past_hour;
    private bool firstCircle;

    protected override void SetClockTimeFromArrowRotation()
    {
        if (clock != null)
        {
            if (clock.currentClockDateTime.Hour < 12)
            {
                firstCircle = true;
            }
            else
            {
                firstCircle = false;
            }

            // Я не понял, как сделать котроллер часовой стрелки :c
            // Надо учитывать, в каком круге мы находимся (0-12, 12-24)
            // Но это оказалась совсем нетривиальная задача
            // Возможно, стоило бы реализовать двойной циферблат для выбора
            // Но я уже и так долго сижу с этим заданием...

            // Мы задаём часам их же время, но меняем часы
            clock.SetDateTime(new DateTime
                (clock.currentClockDateTime.Ticks

                - TimeSpan.FromHours(clock.currentClockDateTime.Hour).Ticks

                + TimeSpan.FromHours(hour).Ticks

                )
            );
            past_hour = hour;
        }
    }
}