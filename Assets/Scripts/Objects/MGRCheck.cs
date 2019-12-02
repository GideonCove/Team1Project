using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Cameron
 * DATE OF CREATION: 12/2/2019
 * SCENE(S) WHERE USED: playground
 * OBJECT(S) WHERE USED: merry_go_round
 * DESCRIPTION: Checks to see if the merry-go-round was fixed and, if so, corrects it.
 */

public class MGRCheck : MonoBehaviour
{
    public static bool mgrSolved = false;

    void Start()
    {
        if (mgrSolved)
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
