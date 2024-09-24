using System;

/// <summary>
/// ����� ��� ������� ������ � IToggleable
/// </summary>
public class ToggleHandler
{
    /// <summary>
    /// ������, �� ���������� �������� ������
    /// </summary>
    public IToggleable toggleableObject;

    /// <summary>
    /// ����� ��� isToggle == true
    /// </summary>
    public Action OnToggleAction;

    /// <summary>
    /// ����� ��� isToggle == false
    /// </summary>
    public Action OffToggleAction;

    /// <summary>
    /// �������� �� Toggle_Event
    /// </summary>
    public void Subscribe()
    {
        if (toggleableObject != null)
        {
            toggleableObject.Toggle_Event += ToggleReaction;
        }
    }

    /// <summary>
    /// ������� �� Toggle_Event
    /// </summary>
    public void UnSubscribe()
    {
        if (toggleableObject != null)
        {
            toggleableObject.Toggle_Event -= ToggleReaction;
        }
    }

    /// <summary>
    /// ��������� Toggle_Enevnt
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
