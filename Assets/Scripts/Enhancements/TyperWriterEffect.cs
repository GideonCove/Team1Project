using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * AUTHOR(S): Gideon Cove
 * DATE OF CREATION: 12/1/2019
 * SCENE(S) WHERE USED: math
 * OBJECT(S) WHERE USED: text
 * DESCRIPTION: Types out messages on the chalkboard in a type writer sort of effect.
 */

public class TyperWriterEffect : MonoBehaviour
{

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showText()); // Starts the code when entering the room.
    }

    IEnumerator showText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i); //running through each individual character in the string, grabbing it, and typing it out.
            this.GetComponent<Text>().text = currentText; // sets the text to the current text.
            yield return new WaitForSeconds(delay); // space of time inbetween each word.
        }
    }
}
