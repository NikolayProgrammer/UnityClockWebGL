using System;

/// <summary>
/// Класс для удобной работы с IToggleable
/// </summary>
public class ToggleHandler
{
    /// <summary>
    /// Объект, за состоянием которого следим
    /// </summary>
    public IToggleable toggleableObject;

    /// <summary>
    /// Метод при isToggle == true
    /// </summary>
    public Action OnToggleAction;

    /// <summary>
    /// Метод при isToggle == false
    /// </summary>
    public Action OffToggleAction;

    /// <summary>
    /// Подписка на Toggle_Event
    /// </summary>
    public void Subscribe()
    {
        if (toggleableObject != null)
        {
            toggleableObject.Toggle_Event += ToggleReaction;
        }
    }

    /// <summary>
    /// Отписка от Toggle_Event
    /// </summary>
    public void UnSubscribe()
    {
        if (toggleableObject != null)
        {
            toggleableObject.Toggle_Event -= ToggleReaction;
        }
    }

    /// <summary>
    /// Обработка Toggle_Enevnt
    /// </summary>
    public void ToggleReaction()
    {
        if (toggleableObject.isToggle)
        {
            OnToggleAction?.Invoke();
        }
        else
        {
            OffToggleAction?.Invoke();
        }
    }
}
