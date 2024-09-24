using UnityEngine;

/// <summary>
/// Абстрактный класс стрелки часов
/// </summary>
public abstract class ClockElement_Arrow : ClockElement
{
    [field: SerializeField] public Transform arrowTransform { get; protected set; }
}