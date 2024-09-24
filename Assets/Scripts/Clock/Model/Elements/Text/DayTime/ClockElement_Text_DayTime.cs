using System;

/// <summary>
/// Текстовый элемент часов - время суток (ЧЧ:ММ:СС)
/// </summary>
public class ClockElement_Text_DayTime : ClockElement_Text
{
    public override void UpdateElement(DateTime dateTime)
    {
        textMeshProUGUI.text = dateTime.ToString("HH:mm:ss");
    }
}
