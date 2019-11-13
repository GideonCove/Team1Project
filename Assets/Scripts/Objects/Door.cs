using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * AUTHOR(S): Seth, Cameron
 * DATE OF CREATION: 10/23/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: player
 * DESCRIPTION: Allows the doors to transport the player to other scenes.
 */

public class Door : MonoBehaviour
{
    public GameObject guiObject;
    public string nextLevel;
    public float destinationX;
    public float destinationY = 1;
    public float destinationZ;
    public string destinationDirection;

    private GameObject player;
    private string currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        guiObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (gameObject.CompareTag("door") && currentScene == SceneManager.GetActiveScene().name)
        {
            guiObject.SetActive(true);

            if (guiObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Space))
            {

                SceneManager.LoadScene(nextLevel);
                Debug.Log("Scene changed to " + nextLevel);

                //Teleport(destinationX, destinationY, destinationZ, destinationDirection);

                Debug.Log("Scene change detected, now teleporting...");
                DontDestroyOnLoad(gameObject);

                if (SceneManager.GetActiveScene().name == nextLevel)
                {
                    player = GameObject.Find("player");

                    player.transform.position = new Vector3(destinationX, destinationY, destinationZ);

                    switch (destinationDirection)
                    {
                        case "north":
                            {
                                player.transform.rotation = Quaternion.Euler(0, 180, 0);
                                break;
                            }
                        case "south":
                            {
                                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                                break;
                            }
                        case "east":
                            {
                                player.transform.rotation = Quaternion.Euler(0, -90, 0);
                                break;
                            }
                        case "west":
                            {
                                player.transform.rotation = Quaternion.Euler(0, 90, 0);
                                break;
                            }
                    }

                    Debug.Log("Successful teleportation in scene " + SceneManager.GetActiveScene().name);
                    Destroy(gameObject);
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {

        guiObject.SetActive(false);
    }

    void Teleport(float destX, float destY, float destZ, string destDir)
    {
        Debug.Log("Scene change detected, now teleporting...");
        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().name == nextLevel)
        {
            player = GameObject.Find("player");

            player.transform.position = new Vector3(destX, destY, destZ);

            switch (destDir)
            {
                case "north":
                    {
                        player.transform.rotation = Quaternion.Euler(0, 180, 0);
                        break;
                    }
                case "south":
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    }
                case "east":
                    {
                        player.transform.rotation = Quaternion.Euler(0, -90, 0);
                        break;
                    }
                case "west":
                    {
                        player.transform.rotation = Quaternion.Euler(0, 90, 0);
                        break;
                    }
            }

            Debug.Log("Successful teleportation in scene " + SceneManager.GetActiveScene().name);
            Destroy(gameObject);
        }
    }
}
