using System;

/// <summary>
/// Текстовый элемент часов - секунда (СС)
/// </summary>
public class ClockElement_Text_Second : ClockElement_Text
{
    public override void UpdateElement(DateTime dateTime)
    {
        textMeshProUGUI.text = dateTime.Second.ToString("D2");
    }
}
