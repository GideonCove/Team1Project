using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Anthony
 * DATE OF CREATION: 11/26/2019
 * SCENE(S) WHERE USED: lobbyTwo
 * OBJECT(S) WHERE USED: family_portrait
 * DESCRIPTION: Shakes the player camera when they click on the familyPortrait object.
 */

public class ShakePlayerCamera : MonoBehaviour
{
    float shakePower = 2;
    float shakeDuration = 0.2f;
    float shakePercentage;
    float InitialAmount;
    float startDuration;
    bool ShouldShake = false;
    bool smooth = true;
    float smoothPower = 10f;
    GameObject playerCamera;

    private void Start()
    {
        playerCamera = GameObject.Find("player_camera");
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShakeCamera();
        }
    }

    void ShakeCamera()
    {
        InitialAmount = shakePower;
        startDuration = shakeDuration;

        if (!ShouldShake) StartCoroutine(Shake());
    }

    public void ShakeCamera(float amount, float duration)
    {
        shakePower += amount;
        InitialAmount = shakePower;
        shakeDuration += duration;
        startDuration = shakeDuration;

        if (!ShouldShake) StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        ShouldShake = true;

        while (shakeDuration > 0.02f)
        {
            Vector3 rotationAmount = Random.insideUnitSphere * shakePower;
            rotationAmount.z = 0;

            shakePercentage = shakeDuration / startDuration;

            shakePower = InitialAmount * shakePercentage;
            shakeDuration = Mathf.Lerp(shakeDuration, 0, Time.deltaTime);


            if (smooth)
            {
                playerCamera.transform.localRotation = Quaternion.Lerp(playerCamera.transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothPower);
            }
            else
            {
                playerCamera.transform.localRotation = Quaternion.Euler(rotationAmount);
            }

            yield return null;
        }

        Destroy(GetComponent<ShakePlayerCamera>());

        playerCamera.transform.localRotation = Quaternion.identity;
        shakePower = 2;
        shakeDuration = 2;
        ShouldShake = false;
    }
}