using System;

/// <summary>
/// Interface of object that can be toggled
/// </summary>
public interface IToggleable
{
    public event Action Toggle_Event;
    public bool isToggle { get; }
}