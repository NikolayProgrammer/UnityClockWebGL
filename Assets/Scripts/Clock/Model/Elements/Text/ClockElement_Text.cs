using UnityEngine;
using TMPro;

/// <summary>
/// Абстрактный класс текстового поля часов
/// </summary>
public abstract class ClockElement_Text : ClockElement
{
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
}
