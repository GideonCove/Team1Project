using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGRCheck : MonoBehaviour
{
    public static bool mgrSolved = false;

    void Start()
    {
        if (mgrSolved)
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
