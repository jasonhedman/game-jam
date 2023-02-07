using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDataDisplay : MonoBehaviour
{
    public float timeRemaining = 2;
    public TMP_Text timeText;
    public GameObject hunter;

    private void Start()
    {
        timeText.color = new Color32(255, 255, 255, 255);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (timeRemaining <= 0)
        {
            Destroy(hunter);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 10)
            {
                timeText.color = new Color32(255, 0, 15, 255);
            }
            DisplayTime(timeRemaining);
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
