using System;

/// <summary>
/// Class for work with IToggleable
/// </summary>
public class ToggleHandler
{
    public IToggleable toggleableObject;

    public Action OnToggleAction;
    public Action OffToggleAction;

    public void Subscribe()
    {
        if (toggleableObject != null)
        {
            toggleableObject.Toggle_Event += ToggleReaction;
        }
    }
    public void UnSubscribe()
    {
        if (toggleableObject != null)
        {
            toggleableObject.Toggle_Event -= ToggleReaction;
        }
    }

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
