using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    // Sensitivity for the movement looking horizontally (x-axis) and vertically (y-axis).
    public float sensitivityHorizontal = 10f;
    public float sensitivityVertical = 10f;

    // This optional float allows us to disable vertical movement in the case we use it for the player's rotation.
    public float optional = 1f;

    // The vertical angle at which the player is looking.
    public float rotationX = 60f;

    // Clamping restrictions.
    public float minVertical = -45f;
    public float maxVertical = 45f;

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorizontal, 0);
        rotationX -= (Input.GetAxis("Mouse Y") * sensitivityVertical) * optional;

        // This clamps the vertical angle.
        rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);

        float rotationY = transform.localEulerAngles.y;

        // Create a new vector for the stored rotation values.
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
