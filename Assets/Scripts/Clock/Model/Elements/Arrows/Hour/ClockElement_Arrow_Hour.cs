using System;
using UnityEngine;

/// <summary>
/// Часовая стрелка
/// </summary>
public class ClockElement_Arrow_Hour : ClockElement_Arrow
{
    public override void UpdateElement(DateTime dateTime)
    {
        arrowTransform.localRotation = Quaternion.Euler(-Vector3.forward * (dateTime.Hour * 30f + dateTime.Minute * 0.5f));
    }
}
