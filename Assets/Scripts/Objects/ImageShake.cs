using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageShake : MonoBehaviour
{
    public GameObject image;
    public float shakeLimit = 1;

    private float originX;
    private float originY;

    private void Awake()
    {
        originX = image.transform.localPosition.x;
        originY = image.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        image.transform.localPosition = new Vector3(originX + Random.Range(-shakeLimit, shakeLimit), originY + Random.Range(-shakeLimit, shakeLimit), transform.localPosition.z);
    }
}
