﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoulAnimation : MonoBehaviour
{
    private float originalY;

    private void Start()
    {
        originalY = gameObject.transform.position.y;
    }

    void Update()
    {
        transform.LookAt(GameObject.Find("player").transform);

        if (SceneManager.GetActiveScene().name != "principals")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (2 * Time.deltaTime), gameObject.transform.position.z);

            if (gameObject.transform.position.y > 20)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, originalY + Mathf.PingPong(0.05f * Time.time, 0.1f), gameObject.transform.position.z);
        }
    }
}
