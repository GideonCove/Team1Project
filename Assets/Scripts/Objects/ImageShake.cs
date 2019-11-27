using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Seth
 * DATE OF CREATION: 11/27/2019
 * SCENE(S) WHERE USED: gameOver
 * OBJECT(S) WHERE USED: game_over_image
 * DESCRIPTION: Let's the game over image DANCE to it's content.
 */

public class ImageShake : MonoBehaviour
{
    public GameObject image;
    public float shakeLimit = 1;

    private float originX;
    private float originY;

    private void Awake()
    {
        Destroy(GameObject.Find("game_controller"));
        GameController.inventoryList.Clear();
        GameController.inventoryUsed.Clear();
        GameController.theItems.Clear();

        Destroy(GameObject.Find("player_canvas"));

        Cursor.visible = true;

        originX = image.transform.localPosition.x;
        originY = image.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        image.transform.localPosition = new Vector3(originX + Random.Range(-shakeLimit, shakeLimit), originY + Random.Range(-shakeLimit, shakeLimit), transform.localPosition.z);
    }
}
