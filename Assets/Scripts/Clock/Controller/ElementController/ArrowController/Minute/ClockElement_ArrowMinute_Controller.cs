using System;
using UnityEngine;

/// <summary>
/// Minute arrow controller
/// </summary>
public class ClockElement_Arrow_Minute_Controller : ClockElement_Arrow_Controller
{
    [SerializeField] protected ClockElement_Arrow_Minute minuteArrow;

    private void Start()
    {
        SetArrow(minuteArrow);
    }

    public void SetArrow(ClockElement_Arrow_Minute arrow)
    {
        if (arrow != null)
        {
            arrowTransform = arrow.transform;
        }
    }

    private int minute;

    protected override void SetClockTimeFromArrowRotation()
    {
        if (clock != null)
        {
            minute = 60 - (int)(arrowTransform.eulerAngles.z * (1f / 6f));

            if(minute >= 60)
            {
                minute = 0;
            }

            clock.SetDateTime(new DateTime
                (clock.currentClockDateTime.Ticks

                - TimeSpan.FromMinutes(clock.currentClockDateTime.Minute).Ticks

                + TimeSpan.FromMinutes(minute).Ticks

                )
            );
        }
    }
}
