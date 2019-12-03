using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Seth
 * DATE OF CREATION: 12/2/2019
 * SCENE(S) WHERE USED: science, lobbyTwo
 * OBJECT(S) WHERE USED: family_portrait, school_flag
 * DESCRIPTION: Allows the principal's items to appear after his request is given.
 */

public class PrincipalsItem : MonoBehaviour
{
    void Start()
    {
        PrincipalScene.played = true;

        if (PrincipalScene.played)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
