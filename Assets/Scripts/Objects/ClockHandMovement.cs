using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
