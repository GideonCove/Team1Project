using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Seth
 * DATE OF CREATION: 11/29/2019
 * SCENE(S) WHERE USED: principals
 * OBJECT(S) WHERE USED: scene_trigger
 * DESCRIPTION: Creates a little scene when entering the principal's office.
 */

public class PrincipalScene : MonoBehaviour
{
    public AudioClip dialogue;

    private static bool played = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!played)
        {
            // Remove commenting once game is completed or something, don't want the sound misfiring in class.
            AudioSource.PlayClipAtPoint(dialogue, gameObject.transform.position);

            played = true;
        }
    }
}
