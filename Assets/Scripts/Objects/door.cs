using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * AUTHOR(S): Seth
 * DATE OF CREATION: 10/23/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: player
 * DESCRIPTION: Allows the doors to transport the player to other scenes.
 */

public class door : MonoBehaviour
{
    public GameObject guiObject;
    public string nextLevel;

    private void Start()
    {
        guiObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (gameObject.CompareTag("door"))
        {

            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Space))
            {
                DontDestroyOnLoad(other);
                SceneManager.LoadScene(nextLevel);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        guiObject.SetActive(false);
    }
}