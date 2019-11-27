using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTracker : MonoBehaviour
{
    public GameObject tree;

    private int soulsAcquired;
    
    void Awake()
    {
        Debug.Log("Woke up!");

        soulsAcquired = (Timer.soulsRemaining - 6) * -1;

        tree.transform.localScale *= soulsAcquired / 10;
    }
}
