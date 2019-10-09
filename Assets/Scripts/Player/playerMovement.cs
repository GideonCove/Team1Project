using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // This script is used to allow the arrow keys to move the player around the game world on the x and z-axes.
    public Vector3 xVector = new Vector3(1f, 0f, 0f);
    public Vector3 zVector = new Vector3(0f, 0f, 1f);
    public float moveSpeed = 7f;

    // Update is called once per frame
    void Update()
    {
        // Increase the position on the x-axis.
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-xVector * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(xVector * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-zVector * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(zVector * moveSpeed * Time.deltaTime, Space.Self);
        }
    }
}
