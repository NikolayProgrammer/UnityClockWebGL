using System;
using UnityEngine;

/// <summary>
/// Minute arrow
/// </summary>
public class ClockElement_Arrow_Minute : ClockElement_Arrow
{
    public override void UpdateElement(DateTime dateTime)
    {
        arrowTransform.localRotation = Quaternion.Euler(-Vector3.forward * (dateTime.Minute * 6f + dateTime.Second * 6f / 60f));
    }
}
