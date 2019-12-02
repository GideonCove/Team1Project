using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * AUTHOR(S): Gideon
 * DATE OF CREATION: 12/1/2019
 * SCENE(S) WHERE USED: math
 * OBJECT(S) WHERE USED: text
 * DESCRIPTION: Types out messages on the chalkboard.
 */

public class TyperWriterEffect : MonoBehaviour
{

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showText());
    }

    IEnumerator showText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
