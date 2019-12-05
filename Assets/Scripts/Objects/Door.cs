using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* 
 * AUTHOR(S): Seth, Cameron
 * DATE OF CREATION: 10/23/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: player
 * DESCRIPTION: Allows the doors to transport the player to other scenes.
 */

public class Door : MonoBehaviour
{
    public GameObject doorText;

    public string nextLevel;
    public float destinationX;
    public float destinationY = 1;
    public float destinationZ;
    public string destinationDirection;
    public bool locked = false;

    private GameObject player;
    private string currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        doorText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        doorText.GetComponent<Text>().text = "[\"SPACE\" to open]";
    }

    private void OnTriggerStay(Collider other)
    {
        if (!locked)
        {
            doorText.SetActive(true);

            if (gameObject.CompareTag("door") && currentScene == SceneManager.GetActiveScene().name)
            {

                if (doorText.activeInHierarchy == true && Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene(nextLevel);
                    Debug.Log("Scene changed to " + nextLevel);

                    PlayerController.destinationX = destinationX;
                    PlayerController.destinationY = destinationY;
                    PlayerController.destinationZ = destinationZ;
                    PlayerController.destinationDirection = destinationDirection;

                    //Teleport(destinationX, destinationY, destinationZ, destinationDirection);
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        doorText.SetActive(false);
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
