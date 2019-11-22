using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Cameron
 * DATE OF CREATION: 11/19/2019
 * SCENE(S) WHERE USED: playground
 * OBJECT(S) WHERE USED: swingset
 * DESCRIPTION: Allows for the swings to swing about.
 */

public class SwingObject : MonoBehaviour
{
    public float delta = 1.5f;
    public float speed = 2.0f;
    public float direction = 1;
    private Quaternion startPos;
    void Start()
    {
        startPos = transform.rotation;
    }
    void Update()
    {
        Quaternion a = startPos;
        a.z += direction * (delta * Mathf.Sin(Time.time * speed));
        transform.rotation = a;
    }
}
