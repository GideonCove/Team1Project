using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text countdownText;
    public float defaultTime = 5f;

    private float currentTime = 0f;
    private int minutes;
    private int seconds;

    void Start()
    {
        // Converts default time from minutes to seconds.
        defaultTime *= 60;

        // Set the timer to the default time given.
        currentTime = defaultTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        // Actively converts currentTime to minutes and seconds to display on screen.
        minutes = Mathf.FloorToInt(currentTime / 60F);
        seconds = Mathf.FloorToInt(currentTime - minutes * 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (minutes == 0 && seconds == 0)
        {
            // Perform game over functions.
        }
    }
}
