using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������� ����� ����������� �������� �����
/// </summary>
public abstract class ClockElement_Controller : MonoBehaviour
{
    /// <summary>
    /// ����, ��� �������� ����������� ����������
    /// </summary>
    [SerializeField] protected Clock clock;

    /// <summary>
    /// ������������ �������� ��� ��������� �����
    /// </summary>
    public virtual void ActivateControl() { }
    
    /// <summary>
    /// �������������� �������� ��� ��������� �����
    /// </summary>
    public virtual void DeactivateControl() { }
}