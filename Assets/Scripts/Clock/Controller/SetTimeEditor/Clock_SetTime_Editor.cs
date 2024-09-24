using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ������� �� �����
/// </summary>
public class Clock_SetTime_Editor : MonoBehaviour
{
    /// <summary>
    /// ����, � �������� �� ��������
    /// </summary>
    [SerializeField] Clock clock;

    /// <summary>
    /// ����� �� ����� �� ��������������
    /// </summary>
    private DateTime clockDateTimeBeforeEdit;

    /// <summary>
    /// ���� �� ���� �������� �� ��������������
    /// </summary>
    private bool clockIsToggleBeforeEdit;

    public void StartEdit()
    {
        clockDateTimeBeforeEdit = clock.currentClockDateTime;
        clockIsToggleBeforeEdit = clock.isToggle;
        clock.StopClock();
    }

    public void ApplyEdit()
    {
        if (clockIsToggleBeforeEdit)
        {
            clock.StartClock();
        }
    }

    public void CancelEdit()
    {
        if (clockIsToggleBeforeEdit)
        {
            clock.SetDateTimeAndStartClock(clockDateTimeBeforeEdit);
        }
        else
        {
            clock.SetDateTime(clockDateTimeBeforeEdit);
        }
    }
}
