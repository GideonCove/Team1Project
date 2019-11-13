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
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            // Ensures the player is not destroyed on new scene loads.
            DontDestroyOnLoad(player);

            SceneManager.LoadScene("lobbyOne");
        }
    }
}
