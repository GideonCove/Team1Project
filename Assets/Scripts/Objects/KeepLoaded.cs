using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * AUTHOR(S): Seth
 * DATE OF CREATION: 11/19/2019
 * SCENE(S) WHERE USED: setup
 * OBJECT(S) WHERE USED: player_canvas
 * DESCRIPTION: Allows for the canvas to be persistent and load directly into the desired scene (should be set to lobbyOne for actual game build).
 */

public class KeepLoaded : MonoBehaviour
{
    public string debugScene = "lobbyOne";

    // This was merely created to keep the player_canvas loaded.
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(debugScene);
    }
}
