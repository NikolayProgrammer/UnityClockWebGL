using System;
using UnityEngine;

/// <summary>
/// Simple script for clock controlling demonstration
/// </summary>
public class ClockController : MonoBehaviour
{
    [SerializeField] private Clock clock;
    private DateTime dateTime => AppTime_Manager.appActualDateTime;

    private void Awake()
    {
        clock.SetDateTimeAndStartClock(dateTime);
    }

    private void OnEnable()
    {
        AppTime_Manager.onNewAppTimeSet_Event += SynchronizeAutomaticaly;
    }
    private void OnDisable()
    {
        AppTime_Manager.onNewAppTimeSet_Event -= SynchronizeAutomaticaly;
    }

    private void SynchronizeAutomaticaly()
    {
        if(clock.isSynchronized)
        {
            SynchronizeClockToAppTime();
        }
    }
    public void SynchronizeClockToAppTime()
    {
        clock.SetDateTime(dateTime);
    }
}