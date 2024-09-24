using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Абстрактный класс контроллера стрелки часов
/// </summary>
public class ClockElement_Arrow_Controller : ClockElement_Controller
{
    protected Transform arrowTransform;

    public override void ActivateControl()
    {
        ControlProcess();
    }

    protected virtual void ControlProcess()
    {
        SetArrowRotation();
        if (clock)
        {
            SetClockTimeFromArrowRotation();
        }
    }

    // Кеширование переменных
    protected Vector3 mousePosition;
    protected Vector3 arrowToMousedirection;
    protected float arrowAngle;

    protected virtual void SetArrowRotation()
    {
        // Поворот стрелки на мышь игрока
        // В перспективе, можно заменить и на поворот в сторону какого-либо объекта (даже 3D)
        // Но сейчас это не требутеся, поэтому пока оставим так
        mousePosition = Input.mousePosition;
        arrowToMousedirection = mousePosition - arrowTransform.position;
        arrowAngle = Vector2.SignedAngle(Vector2.up, arrowToMousedirection);
        arrowTransform.eulerAngles = new Vector3(0, 0, arrowAngle);
    }

    protected virtual void SetClockTimeFromArrowRotation() { }
}