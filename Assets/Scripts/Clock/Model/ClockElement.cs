using System;
using UnityEngine;

/// <summary>
/// ����������� ����� �������� �����
/// </summary>
public abstract class ClockElement : MonoBehaviour
{
    public virtual void UpdateElement(DateTime dateTime) { }
}