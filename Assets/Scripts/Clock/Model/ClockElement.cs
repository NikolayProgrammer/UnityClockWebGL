using System;
using UnityEngine;

/// <summary>
/// Абстрактный класс элемента часов
/// </summary>
public abstract class ClockElement : MonoBehaviour
{
    public virtual void UpdateElement(DateTime dateTime) { }
}