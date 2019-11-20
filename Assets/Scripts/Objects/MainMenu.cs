using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * AUTHOR(S): Seth
 * DATE OF CREATION: 10/24/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: all objects that can be picked up
 * DESCRIPTION: Ensures the player is not destroyed on load, allowing for inventory and player persistence.
 */

public class MainMenu : MonoBehaviour
{
    public void ButtonClick()
    {
        switch (gameObject.name)
        {
            case "start_button":
                SceneManager.LoadScene("lobbyOne");
                break;
            case "tutorial_button":
                SceneManager.LoadScene("tutorial");
                break;
            case "settings_button":
                break;
            case "quit_button":
                Application.Quit();
                break;
            case "main_menu_button":
                SceneManager.LoadScene("mainMenu");
                break;
        }
    }
}
