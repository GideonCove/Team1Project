using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * AUTHOR(S): Seth, Gideon, Cameron, Anthony, Zach
 * DATE OF CREATION: 11/29/2019
 * SCENE(S) WHERE USED: lobbyOne
 * OBJECT(S) WHERE USED: intro_canvas
 * DESCRIPTION: Provides a bit of context to the player as to what their objective is.
 */

public class Intro : MonoBehaviour
{
    public Text introTextTop;
    [TextArea]
    public string lineTop = "";
    public float lengthOfFadeInTop = 1f;

    public Text introTextMiddle;
    [TextArea]
    public string lineMiddle = "";
    public float lengthOfFadeInMiddle = 1f;

    public Text introTextBottom;
    [TextArea]
    public string lineBottom = "";
    public float lengthOfFadeInBottom = 1f;

    private static bool played = true;

    private void Start()
    {
        if (!played)
        {
            Debug.Log("Running, not played");

            introTextTop.text = lineTop;
            introTextMiddle.text = lineMiddle;
            introTextBottom.text = lineBottom;

            StartCoroutine(FadeIn(lengthOfFadeInTop, introTextTop));
            StartCoroutine(FadeIn(lengthOfFadeInMiddle, introTextMiddle));
            StartCoroutine(FadeIn(lengthOfFadeInBottom, introTextBottom));

            Debug.Log("End of while, setting played to true");

            played = true;
        }
        else
        {
            introTextTop.color = new Color(introTextTop.color.r, introTextTop.color.g, introTextTop.color.b, 0);
            introTextMiddle.color = new Color(introTextMiddle.color.r, introTextMiddle.color.g, introTextMiddle.color.b, 0);
            introTextBottom.color = new Color(introTextBottom.color.r, introTextBottom.color.g, introTextBottom.color.b, 0);
        }
    }

    public IEnumerator FadeIn(float l, Text t)
    {
        t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
        while (t.color.a < 1.0f)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a + (Time.deltaTime / l));
            yield return null;
        }

        StartCoroutine(FadeOut(l, t));
    }

    public IEnumerator FadeOut(float l, Text t)
    {
        while (t.color.a > 0.0f)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - (Time.deltaTime / l));
            yield return null;
        }
    }
}
