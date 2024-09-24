using System;
using UnityEngine;

/// <summary>
/// Abstract clock element
/// </summary>
public abstract class ClockElement : MonoBehaviour
{
    public virtual void UpdateElement(DateTime dateTime) { }
}