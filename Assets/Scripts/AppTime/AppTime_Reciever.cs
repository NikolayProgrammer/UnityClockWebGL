using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Request for new global app time
/// </summary>
public class AppTime_Reciever : MonoBehaviour
{
    public event Action<DateTime> onRequestAppTimeEnded_Event;

    private UnityWebRequest webRequest;
    private List<string> URLs = new()
    {
            "https://google.com",
            "https://yandex.com",
            "https://www.opera.com"
    };

    DateTime recievedDateTime;
    string str_date;

    public IEnumerator RequestAppTime_COR()
    {
        foreach (var url in URLs)
        {
            webRequest = UnityWebRequest.Get(url);
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log($"Web-request to {url} failed. Error: {webRequest.error}");
                continue;
            }
            else
            {
                str_date = webRequest.GetResponseHeader("DATE");

                if (str_date == null)
                {
                    Debug.Log($"Web-resource {url} didn't give \" DATE \" header!");
                    continue;
                }

                if (!DateTime.TryParse(str_date, out recievedDateTime))
                {
                    yield return null;
                }

                Debug.Log($"Web-resource {url} gived date: {recievedDateTime.ToString()}");
                onRequestAppTimeEnded_Event?.Invoke(recievedDateTime);

                yield break;
            }
        }

        // In this case we could add specfic events like onAppUseLocalTime or etc.
        Debug.Log($"All Http requests failed. Return device time {DateTime.Now.ToString("HH:mm:ss")}");
        recievedDateTime = DateTime.Now;
        onRequestAppTimeEnded_Event?.Invoke(recievedDateTime);
    }
}