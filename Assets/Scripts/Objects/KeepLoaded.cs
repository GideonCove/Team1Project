using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
