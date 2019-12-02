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
    public float orbitSpeed = 30f;

    private GameObject orbitCenter;

    void Start()
    {
        orbitCenter = GameObject.Find("orbit_center");
    }
    
    void Update()
    {
        if (SolvePuzzle.planetsSolved)
        {
            orbitAround();
        }
    }

    void orbitAround()
    {
        transform.RotateAround(orbitCenter.transform.position, new Vector3(0, 1f, 0), orbitSpeed * Time.deltaTime);
    }
}
