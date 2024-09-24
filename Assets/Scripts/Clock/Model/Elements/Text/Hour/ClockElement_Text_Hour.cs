using System;

/// <summary>
/// ��������� ������� ����� - ��� (��)
/// </summary>
public class ClockElement_Text_Hour : ClockElement_Text
{
    public override void UpdateElement(DateTime dateTime)
    {
        textMeshProUGUI.text = dateTime.Hour.ToString("D2");
    }
}
