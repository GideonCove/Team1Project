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

    float shakePower = 5;
    float shakeDuration = 1;
    float shakePercentage;
    float InitialAmount;
    float startDuration;
    bool ShouldShake = false;
    bool smooth = false;
    float smoothPower = 10f;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothPower);
            else
                transform.localRotation = Quaternion.Euler(rotationAmount);

            yield return null;
        }

        transform.localRotation = Quaternion.identity;
        shakePower = 2;
        shakeDuration = 2;
        ShouldShake = false;
    }

}