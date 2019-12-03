using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
* AUTHOR(S): Anthony
* DATE OF CREATION: 12/2/2019
* SCENE(S) WHERE USED: bathroom
* OBJECT(S) WHERE USED: bathroom_stall
* DESCRIPTION: Changes the material of the object to show different colors.
*/

public class ChangeMaterial : MonoBehaviour
{
    public Material materialOne;
    public Material materialTwo;
    public float switchSpeed = 1.0f;;

    void Start()
    {
        Invoke("m1", 0f);
    }

    void m1()
    {
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().material = materialOne;
            Invoke("m2", switchSpeed);
        }
    }

    void m2()
    {
        if (GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().material = materialTwo;
            Invoke("m1", switchSpeed);
        }
    }
}
