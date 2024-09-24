using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Управление глобальным временем приложения
/// </summary>
public class AppTime_Manager : MonoBehaviour
{
    /// <summary>
    /// Приложение установило новое глобальное время
    /// </summary>
    public static Action onNewAppTimeSet_Event;

    /// <summary>
    /// Актуальное время приложения
    /// </summary>
    public static DateTime appActualDateTime { get; private set; }

    [SerializeField] private AppTime_Reciever reciever;
    private AppTime_Handler handler = new();

    private void Awake()
    {
        reciever.onRequestAppTimeEnded_Event += SetNewAppDateTime;
        StartCoroutine(reciever.RequestAppTime_COR());
    }   

    private void SetNewAppDateTime(DateTime dateTime)
    {
        appActualDateTime = dateTime;

        handler.SetAppDateTime(dateTime);
        StartCoroutine(UpdateGlobalTime_COR());
        StartCoroutine(CheckForCorrection_COR());

        onNewAppTimeSet_Event?.Invoke();
    }

    private IEnumerator UpdateGlobalTime_COR()
    {
        while (true)
        {
            appActualDateTime = handler.GetActualAppDateTime();
            yield return null;
        }
    }

    private IEnumerator CheckForCorrection_COR()
    {
        double startDelay = Time.realtimeSinceStartupAsDouble;
        while (true)
        {
            if (Time.realtimeSinceStartupAsDouble - startDelay >= 3600)
            {
                StartCoroutine(reciever.RequestAppTime_COR());
                yield break;
            }
            yield return null;
        }
    }
}