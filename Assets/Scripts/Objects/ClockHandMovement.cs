using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Cameron, Seth
 * DATE OF CREATION: 11/19/2019
 * SCENE(S) WHERE USED: lobbyOne
 * OBJECT(S) WHERE USED: clock
 * DESCRIPTION: Allows for the hands of a clock to be rotated about.
 */

public class ClockHandMovement : MonoBehaviour
{
    public GameObject ClockHand;
    public float speed;
    void Update()
    {
        OrbitAround();
    }
    void OrbitAround()
    {
        transform.RotateAround(ClockHand.transform.position, new Vector3(1f, 0f, 0f), 90f * Time.deltaTime * speed);
    }
}
