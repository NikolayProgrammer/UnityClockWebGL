using UnityEngine;

/// <summary>
/// ����������� ����� ������� �����
/// </summary>
public abstract class ClockElement_Arrow : ClockElement
{
    [field: SerializeField] public Transform arrowTransform { get; protected set; }
}