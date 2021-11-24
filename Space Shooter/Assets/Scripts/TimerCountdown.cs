using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{

    public GameObject textDisplay;
    public int seconds = 0;
    public bool takingAway = false;




    public Text timeRecordText;
    public int timeRecord = 0;



    private void Start()
    {
        textDisplay.GetComponent<Text>().text = "00 : " + seconds.ToString();
    }

    private void Update()
    {
        if (takingAway == false)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        seconds -= 1;
        if (seconds < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + seconds.ToString();
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + seconds.ToString();
        }
        textDisplay.GetComponent<Text>().text = "00:" + seconds.ToString();
        takingAway = false;
    }
}
