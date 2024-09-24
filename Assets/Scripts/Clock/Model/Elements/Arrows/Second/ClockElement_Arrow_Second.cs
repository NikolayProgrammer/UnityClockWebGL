using System;
using UnityEngine;

/// <summary>
/// Second arrow
/// </summary>
public class ClockElement_Arrow_Second : ClockElement_Arrow
{
    public override void UpdateElement(DateTime dateTime)
    {
        arrowTransform.localRotation = Quaternion.Euler(-Vector3.forward * (dateTime.Second * 6f + (dateTime.Millisecond / 1000f) * 6f));
    }
}
