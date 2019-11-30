using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * AUTHOR(S): Zach, Seth
 * DATE OF CREATION: 11/30/2019
 * SCENE(S) WHERE USED: music
 * OBJECT(S) WHERE USED: note_canvas
 * DESCRIPTION: Alters spawned prefabs to change sprites as well as rotate and float.
 */

public class NoteAnimation : MonoBehaviour
{
    public float timeAlive = 10f;
    public Sprite[] noteSprites = new Sprite[9];

    private float spin;
    private float floatSpeed;

    void Start()
    {
        gameObject.GetComponentInChildren<Image>().sprite = noteSprites[Random.Range(0, 8)];
        spin = Random.Range(1f, 20f);
        floatSpeed = Random.Range(1f, 6f);
    }
    
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, gameObject.transform.rotation.y + (spin), 0));
        gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (floatSpeed * Time.deltaTime), gameObject.transform.position.z);

        Destroy(gameObject, timeAlive);
    }
}
