using System;

/// <summary>
/// ��������� �������, ������� ����������/����������� �� ���� ������
/// </summary>
public interface IToggleable
{
    public event Action Toggle_Event;
    public bool isToggle { get; }
}