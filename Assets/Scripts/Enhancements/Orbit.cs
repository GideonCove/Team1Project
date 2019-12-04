using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Mary, Gideon
 * DATE OF CREATION: 11/26/2019
 * SCENE(S) WHERE USED: astronomy
 * OBJECT(S) WHERE USED: planets
 * DESCRIPTION: Orbits planets around eachother after puzzle solved.
 */

public class Orbit : MonoBehaviour
{
    public float orbitSpeed = 30f; // sets the speed for the planet orbit.
    public bool isPuzzlePlanet = false;

    private GameObject orbitCenter; // makes it so the planets orbit around this point.

    void Start()
    {
        orbitCenter = GameObject.Find("orbit_center");

        if (SolvePuzzle.planetsSolved && isPuzzlePlanet)
        {
            gameObject.SetActive(true); // makes the planet visible so that people can see it orbit.
        }
        else if (!SolvePuzzle.planetsSolved && isPuzzlePlanet)
        {
            gameObject.SetActive(false); 
        }
    }
    
    void Update()
    {
        if (SolvePuzzle.planetsSolved)
        {
            orbitAround(); // makes the planets rotate constantly.

            Debug.Log(gameObject.name + " is puzzle planet: " + isPuzzlePlanet);
            if (isPuzzlePlanet)
            {
                gameObject.SetActive(true);
                Debug.Log(gameObject.name + " is now active");
            }
        }
    }

    void orbitAround()
    {
        transform.RotateAround(orbitCenter.transform.position, new Vector3(0, 1f, 0), orbitSpeed * Time.deltaTime); //the actual orbit code. This makes the planet rotate.
    }
}
