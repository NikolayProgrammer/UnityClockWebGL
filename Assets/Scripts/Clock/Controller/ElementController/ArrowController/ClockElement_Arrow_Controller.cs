using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������� ����� ����������� ������� �����
/// </summary>
public class ClockElement_Arrow_Controller : ClockElement_Controller
{
    protected Transform arrowTransform;

    public override void ActivateControl()
    {
        ControlProcess();
    }

    protected virtual void ControlProcess()
    {
        SetArrowRotation();
        if (clock)
        {
            SetClockTimeFromArrowRotation();
        }
    }

    // ����������� ����������
    protected Vector3 mousePosition;
    protected Vector3 arrowToMousedirection;
    protected float arrowAngle;

    protected virtual void SetArrowRotation()
    {
        // ������� ������� �� ���� ������
        // � �����������, ����� �������� � �� ������� � ������� ������-���� ������� (���� 3D)
        // �� ������ ��� �� ���������, ������� ���� ������� ���
        mousePosition = Input.mousePosition;
        arrowToMousedirection = mousePosition - arrowTransform.position;
        arrowAngle = Vector2.SignedAngle(Vector2.up, arrowToMousedirection);
        arrowTransform.eulerAngles = new Vector3(0, 0, arrowAngle);
    }

    protected virtual void SetClockTimeFromArrowRotation() { }
}