using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerLabel;

    private int minutes = 0;
    private float seconds;

    private void Update()
    {
        seconds += Time.deltaTime; //every second it adds 1

        var miliSeconds = (seconds * 100) % 100;

        if(seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }

        timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, miliSeconds);

    }
}
