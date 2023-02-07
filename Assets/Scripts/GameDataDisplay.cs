using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDataDisplay : MonoBehaviour
{
    public TMP_Text timeText;
    public float timeRemaining = 60;
    public bool timerOn = false;

    public TMP_Text score;
    public int mouseScore = 0;
    public int catScore = 0;

    public TMP_Text level;
    public int levelCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        timeText.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        timerRun();

        score.text = string.Format("{0} : {1}", catScore, mouseScore);

        level.text = string.Format("Level {0}", levelCount);
    }

    void timerRun()
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
                levelFinished(true);
                timeRemaining = 60;
                timerOn = true;
            }

            if (timeRemaining < 10)
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

    void levelFinished(bool mouseWin)
    {
        if (mouseWin)
        {
            mouseScore++;
        }
        else
        {
            catScore++;
        }
    }
}
