using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* 
 * AUTHOR(S): Seth, Cameron
 * DATE OF CREATION: 10/24/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: Menu buttons within the main menu, tutorial, and settings.
 * DESCRIPTION: Allows for button functions based on button name.
 */

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        switch (gameObject.name)
        {
            case "brightness_slider":
                gameObject.GetComponent<Slider>().value = GameController.brightness;
                break;
            case "speed_slider":
                gameObject.GetComponent<Slider>().value = GameController.speed;
                break;
            case "volume_slider":
                gameObject.GetComponent<Slider>().value = AudioListener.volume;
                break;
        }
    }

    public void ButtonClick()
    {
        switch (gameObject.name)
        {
            case "start_button":
                SceneManager.LoadScene("setup");
                break;
            case "tutorial_button":
                SceneManager.LoadScene("tutorial");
                break;
            case "settings_button":
                SceneManager.LoadScene("settings");
                break;
            case "quit_button":
                Application.Quit();
                break;
            case "main_menu_button":
                SceneManager.LoadScene("mainMenu");
                break;
            case "brightness_slider":
                GameController.brightness = gameObject.GetComponent<Slider>().value;
                break;
            case "speed_slider":
                GameController.speed = gameObject.GetComponent<Slider>().value;
                break;
            case "volume_slider":
                AudioListener.volume = gameObject.GetComponent<Slider>().value;
                break;
        }
    }
}
