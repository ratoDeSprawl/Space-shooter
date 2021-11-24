using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timeActive = true;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;
    public int timeRecord = 0;

    void Start()
    {
       
        currentTime = startMinutes;
    }

    
    void Update()
    {
        if (timeActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
        //currentTimeText.text = time.Minutes.ToString()+ ":"+ time.Seconds.ToString();
    }
}
