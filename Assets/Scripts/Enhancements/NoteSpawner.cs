using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Zach
 * DATE OF CREATION: 11/30/2019
 * SCENE(S) WHERE USED: music
 * OBJECT(S) WHERE USED: note_spawner
 * DESCRIPTION: Spawns notes in random places and rotations.
 */

public class NoteSpawner : MonoBehaviour
{
    public GameObject note;
    public float radius = 10f;
    public int notesPerSecond = 3;

    private GameObject newNote;
    private Vector3 position;
    private Quaternion rotation;

    private void Start()
    {
        InvokeRepeating("NoteSpawn", 1, notesPerSecond);
    }

    void NoteSpawn()
    {
        position = new Vector3(gameObject.transform.position.x + Random.Range(-radius, radius), 0f, gameObject.transform.position.z + Random.Range(-radius, radius));
        rotation = new Quaternion(0, Random.Range(0, 359), 0, 0);

        newNote = Instantiate(note, position, rotation);
    }
}
