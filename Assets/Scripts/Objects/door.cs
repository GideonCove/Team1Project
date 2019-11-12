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
    public float destinationX;
    public float destinationY = 1;
    public float destinationZ;
    public string destinationDirection;

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
                other.transform.position = new Vector3(destinationX, destinationY, destinationZ);

                switch (destinationDirection) {
                    case "north":
                        {
                            other.transform.rotation = Quaternion.Euler(0, 180, 0);
                            break;
                        }
                    case "south":
                        {
                            other.transform.rotation = Quaternion.Euler(0, 0, 0);
                            break;
                        }
                    case "east":
                        {
                            other.transform.rotation = Quaternion.Euler(0, -90, 0);
                            break;
                        }
                    case "west":
                        {
                            other.transform.rotation = Quaternion.Euler(0, 90, 0);
                            break;
                        }
                }

                SceneManager.LoadScene(nextLevel);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        guiObject.SetActive(false);
    }
}