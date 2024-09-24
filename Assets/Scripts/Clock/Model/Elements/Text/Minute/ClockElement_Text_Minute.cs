using System;

/// <summary>
/// Текстовый элемент часов - минута (ММ)
/// </summary>
public class ClockElement_Text_Minute : ClockElement_Text
{
    public override void UpdateElement(DateTime dateTime)
    {
        textMeshProUGUI.text = dateTime.Minute.ToString("D2");
    }
}
