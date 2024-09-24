using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Изменение картинки по isToggle у IToggleable
/// </summary>
public class UI_Toggle_Image : MonoBehaviour
{
    protected readonly ToggleHandler handler = new();

    [SerializeField] protected GameObject toggleableObject;
    [SerializeField] protected Image toggleImage;
    [SerializeField] protected Sprite toggleOnSprite;
    [SerializeField] protected Sprite toggleOffSprite;

    protected void OnToggle()
    {
        toggleImage.sprite = toggleOnSprite;
    }
    protected void OffToggle()
    {
        toggleImage.sprite = toggleOffSprite;
    }

    private void Awake()
    {
        handler.toggleableObject = toggleableObject.GetComponent<IToggleable>();
        handler.OnToggleAction = OnToggle;
        handler.OffToggleAction = OffToggle;
    }
    private void OnEnable()
    {
        handler.Subscribe();
        if(handler.toggleableObject.isToggle)
        {
            OnToggle();
        }
    }
    private void OnDisable()
    {
        handler.UnSubscribe();
    }
    private void OnDestroy()
    {
        handler.UnSubscribe();
    }
}
