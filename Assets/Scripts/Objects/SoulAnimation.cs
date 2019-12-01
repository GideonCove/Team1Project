using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulAnimation : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (2 * Time.deltaTime), gameObject.transform.position.z);

        if (gameObject.transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
}
