using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 // * AUTHOR(S): Anthony
// * DATE OF CREATION: 2/1/2019
// * SCENE(S) WHERE USED: Bathroom
// * OBJECT(S) WHERE USED: Bathroom_stall
// * DESCRIPTION: changes material of the oject
 


public class ChangeMaterial : MonoBehaviour
{
    public Material greenMaterial;
    public Material blueMaterial;


    void Start()
    {



        Invoke("m1", 1.0f);

    }

    void m1()
    {

        GetComponent<Renderer>().material = greenMaterial;
        Invoke("m2", 1.0f);

    }

    void m2()
    {

        GetComponent<Renderer>().material = blueMaterial;
        Invoke("m1", 1.0f);

    }


    void Update()
    {
        
    }
}
