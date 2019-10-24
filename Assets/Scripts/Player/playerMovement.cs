using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Seth, Gideon, Zach, Anthony
 * DATE OF CREATION: 10/9/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: player
 * DESCRIPTION: Allows WASD to be used for player movement according to where the player is looking.
 */

public class playerMovement : MonoBehaviour
{
    // GameObject array created for keeping inventory.
    static public GameObject[] inventory = new GameObject[12];

    // This script is used to allow the arrow keys to move the player around the game world on the x and z-axes.
    public Vector3 xVector = new Vector3(1f, 0f, 0f);
    public Vector3 zVector = new Vector3(0f, 0f, 1f);
    public float moveSpeed = 7f;

    // Update is called once per frame
    void Update()
    {
        // Moves forward (negatively on the x-axis).
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-xVector * moveSpeed * Time.deltaTime, Space.Self);
        }

        // Moves backward (positively on the x-axis).
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(xVector * moveSpeed * Time.deltaTime, Space.Self);
        }

        // Moves forward (negatively on the z-axis).
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-zVector * moveSpeed * Time.deltaTime, Space.Self);
        }

        // Moves forward (positively on the z-axis).
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(zVector * moveSpeed * Time.deltaTime, Space.Self);
        }
    }
}
