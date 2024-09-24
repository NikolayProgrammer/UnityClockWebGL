using System;

/// <summary>
/// Clock text element - day of time (HH:mm:ss)
/// </summary>
public class ClockElement_Text_DayTime : ClockElement_Text
{
    public override void UpdateElement(DateTime dateTime)
    {
        textMeshProUGUI.text = dateTime.ToString("HH:mm:ss");
    }
}
