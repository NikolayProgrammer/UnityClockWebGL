using System;
using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// Transferring DateTime to clock from text input
/// </summary>
public class UI_Input_DateTime_Accept : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HH_text;
    [SerializeField] private TextMeshProUGUI mm_text;
    [SerializeField] private TextMeshProUGUI ss_text;

    [SerializeField] private Clock clock;

    private int hour = 0;
    private int minute = 0;
    private int second = 0;

    public void ApplyTime()
    {
        int.TryParse(string.Join("", HH_text.text.Where(c => char.IsDigit(c))), out hour);
        int.TryParse(string.Join("", mm_text.text.Where(c => char.IsDigit(c))), out minute);
        int.TryParse(string.Join("", ss_text.text.Where(c => char.IsDigit(c))), out second);

        clock.SetDateTime(new DateTime(clock.currentClockDateTime.Date.Ticks
            + TimeSpan.FromHours(hour).Ticks
            + TimeSpan.FromMinutes(minute).Ticks
            + TimeSpan.FromSeconds(second).Ticks)
        );
    }
}