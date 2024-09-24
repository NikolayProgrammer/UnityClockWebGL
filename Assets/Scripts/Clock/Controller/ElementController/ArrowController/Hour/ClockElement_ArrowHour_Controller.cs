using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hour arrow controller (doesn't work!)
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

    private int hour;
    private int past_hour;
    private bool firstCircle;

    protected override void SetClockTimeFromArrowRotation()
    {
        // Ya ne ponyal kak eto sdelat :C
        // pomogite...

        /*
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

            clock.SetDateTime(new DateTime
                (clock.currentClockDateTime.Ticks

                - TimeSpan.FromHours(clock.currentClockDateTime.Hour).Ticks

                + TimeSpan.FromHours(hour).Ticks

                )
            );
            past_hour = hour;
        }
        */
    }
}