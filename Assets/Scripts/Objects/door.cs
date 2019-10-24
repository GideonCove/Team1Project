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
        Debug.Log("Hey what's up");

        if (gameObject.CompareTag("door"))
        {

            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
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