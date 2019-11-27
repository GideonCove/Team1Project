using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* 
 * AUTHOR(S): Gideon
 * DATE OF CREATION: 11/26/2019
 * SCENE(S) WHERE USED: math
 * OBJECT(S) WHERE USED: chalkboard_text
 * DESCRIPTION: Fades in chalkboard_text when near.
 */

public class Fade : MonoBehaviour
{
    public float fadeRate;
    private Image text;
    private float targetAlpha;
   
    void Start()
    {
        this.text = this.GetComponent<Image>();
        if (this.text == null)
        {
            Debug.LogError("Error: No image on " + this.name);
        }
        this.targetAlpha = this.text.color.a;
    }

    
    void Update()
    {
        Color curColor = this.text.color;
        float alphaDiff = Mathf.Abs(curColor.a - this.targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, this.fadeRate * Time.deltaTime);
            this.text.color = curColor;
        }
    }

    public void fadeOut()
    {
        this.targetAlpha = 0.0f;
    }

    public void fadeIn()
    {
        this.targetAlpha = 1.0f;
    }
}
