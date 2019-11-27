using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Zach
 * DATE OF CREATION: 11/26/2019
 * SCENE(S) WHERE USED: science
 * OBJECT(S) WHERE USED: tree
 * DESCRIPTION: Changes the scale of the tree based on souls collected.
 */

public class TreeTracker : MonoBehaviour
{
    public GameObject tree;

    private float soulsAcquired;
    
    void Start()
    {
        // Convert remaining souls to acquired through some math magic.
        soulsAcquired = (Timer.soulsRemaining - 6) * -1;

        // Transform the base scale of the tree to a new scale.
        tree.transform.localScale = new Vector3(0.05f + (soulsAcquired* 0.02f), 0.05f + (soulsAcquired * 0.02f), 0.05f + (soulsAcquired * 0.02f));
    }
}
