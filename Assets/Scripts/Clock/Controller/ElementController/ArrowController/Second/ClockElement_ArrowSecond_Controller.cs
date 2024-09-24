using System;
using UnityEngine;

/// <summary>
/// Second arrow controller
/// </summary>
public class ClockElement_Arrow_Second_Controller : ClockElement_Arrow_Controller
{
    [SerializeField] protected ClockElement_Arrow_Second secondArrow;

    private void Start()
    {
        SetArrow(secondArrow);
    }

    public void SetArrow(ClockElement_Arrow_Second arrow)
    {
        if (arrow != null)
        {
            arrowTransform = arrow.transform;
        }
    }

    private double second;

    protected override void SetClockTimeFromArrowRotation()
    {
        if (clock != null)
        {
            second = 60 - (int)(arrowTransform.eulerAngles.z * (1f / 6f));

            if (second >= 60)
            {
                second = 0;
            }

            clock.SetDateTime(new DateTime
                (clock.currentClockDateTime.Ticks

                - TimeSpan.FromSeconds(clock.currentClockDateTime.Second).Ticks
                - TimeSpan.FromMilliseconds(clock.currentClockDateTime.Millisecond).Ticks

                + TimeSpan.FromSeconds(second).Ticks

                )
            );
        }
    }
}