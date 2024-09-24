using System;
using UnityEngine;

/// <summary>
/// ������ ����������� ����������� �������
/// </summary>
public class AppTime_Handler
{
    private DateTime setAppDateTime;
    private double setAppDateTimeDelay;

    /// <summary>
    /// ���������� ���������� �������
    /// </summary>
    public void SetAppDateTime(DateTime dateTime)
    {
        setAppDateTime = dateTime;
        setAppDateTimeDelay = Time.realtimeSinceStartupAsDouble;
    }

    /// <summary>
    /// �������� ���������� �����
    /// </summary>
    public DateTime GetActualAppDateTime()
    {
        return new
            DateTime(setAppDateTime.Ticks + TimeSpan.FromSeconds(Time.realtimeSinceStartupAsDouble - setAppDateTimeDelay).Ticks);
    }

    /// <summary>
    /// �������� ��������� DateTime � ����������� �������
    /// </summary>
    public void ChangeDateTimeToAppDateTime(ref DateTime dateTime)
    {
        dateTime = GetActualAppDateTime();
    }
}
