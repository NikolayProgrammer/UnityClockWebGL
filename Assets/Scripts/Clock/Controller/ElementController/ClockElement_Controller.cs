using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract controller of clock element
/// </summary>
public abstract class ClockElement_Controller : MonoBehaviour
{
    [SerializeField] protected Clock clock;

    public virtual void ActivateControl() { }
    public virtual void DeactivateControl() { }
}