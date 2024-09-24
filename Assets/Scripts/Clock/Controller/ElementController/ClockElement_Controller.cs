using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Абстрактный класс контроллера элемента часов
/// </summary>
public abstract class ClockElement_Controller : MonoBehaviour
{
    /// <summary>
    /// Часы, над которыми планируется управление
    /// </summary>
    [SerializeField] protected Clock clock;

    /// <summary>
    /// Активировать контроль над элементом часов
    /// </summary>
    public virtual void ActivateControl() { }
    
    /// <summary>
    /// Деактивировать контроль над элементом часов
    /// </summary>
    public virtual void DeactivateControl() { }
}