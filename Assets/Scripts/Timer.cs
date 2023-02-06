using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timerOn = false;
    public TMP_Text timeText;

    private void Start()
    {
        timerOn = true;
        timeText.color = new Color32(255, 255, 255, 255);
    }
    void Update()
    {
        if (timerOn)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                timeRemaining = 0;
                timerOn = false;
            }

            if(timeRemaining < 10)
            {
                timeText.color = new Color32(255, 0, 15, 255);
            }
        }
    }
    void DisplayTime(float display)
    {
        display += 1;
        float minutes = Mathf.FloorToInt(display / 60);
        float seconds = Mathf.FloorToInt(display % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
