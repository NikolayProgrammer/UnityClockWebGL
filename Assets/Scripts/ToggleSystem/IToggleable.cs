using System;

/// <summary>
/// Интерфейс объекта, который включается/выключается по ходу работы
/// </summary>
public interface IToggleable
{
    public event Action Toggle_Event;
    public bool isToggle { get; }
}