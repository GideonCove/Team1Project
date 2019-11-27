using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * AUTHOR(S): Seth, Cameron, Gideon, Zach, Anthony
 * DATE OF CREATION: 11/24/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: soul_timer
 * DESCRIPTION: Sets a base timer and detects if it is over.
 */

public class Timer : MonoBehaviour
{
    public Text countdownText;
    public Text soulsText;
    public float defaultTime = 5f;

    public static float currentTime = 0f;
    private int minutes;
    private int seconds;

    public static int soulsRemaining = 6;

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
        soulsText.text = soulsRemaining.ToString();

        if (minutes == 0 && seconds == 0)
        {
            // Perform game over functions.
        }
    }
}
