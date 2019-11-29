using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Seth
 * DATE OF CREATION: 11/29/2019
 * SCENE(S) WHERE USED: gym
 * OBJECT(S) WHERE USED: loose_basketball
 * DESCRIPTION: Checks whether the ball was already collected or not and, if so, deletes it.
 */

public class BasketballSpawn : MonoBehaviour
{
    private static bool gotBall = false;

    private void Awake()
    {
        if (gotBall)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            gotBall = true;
        }
    }
}
