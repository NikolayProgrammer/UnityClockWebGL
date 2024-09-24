using System;

/// <summary>
/// ��������� ������� ����� - ����� ����� (��:��:��)
/// </summary>
public class ClockElement_Text_DayTime : ClockElement_Text
{
    public override void UpdateElement(DateTime dateTime)
    {
        textMeshProUGUI.text = dateTime.ToString("HH:mm:ss");
    }
}
