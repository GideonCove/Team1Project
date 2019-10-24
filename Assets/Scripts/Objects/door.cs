using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("Trigger detected");

        if (gameObject.CompareTag("door"))
        {
            Debug.Log("Does have door tag");

            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Hit E");

                SceneManager.LoadScene(nextLevel);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger undetected");

        guiObject.SetActive(false);
    }
}