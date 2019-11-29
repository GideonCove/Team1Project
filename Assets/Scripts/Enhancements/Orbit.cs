using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Gideon, Mary
 * DATE OF CREATION: 11/26/2019
 * SCENE(S) WHERE USED: astronomy
 * OBJECT(S) WHERE USED: planets
 * DESCRIPTION: Orbits planets around eachother after puzzle solved.
 */

public class Orbit : MonoBehaviour
{
    public GameObject insideSun;
    void Start()
    {
        insideSun = GameObject.Find("centerSolarSystem");
    }

    
    // Update is called once per frame
    void Update()
    {
        orbitAround();
        spinOnTheAxis();
    }

    void orbitAround()
    {
        transform.RotateAround(insideSun.transform.position, new Vector3(0, 0, 1f), 45f * Time.deltaTime);
    }

    void spinOnTheAxis()
    {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), 500f * Time.deltaTime);
    }
}
