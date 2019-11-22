using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
 * AUTHOR(S): Seth, Cameron, Gideon, Zach, Anthony
 * DATE OF CREATION: 11/21/2019
 * SCENE(S) WHERE USED: TBD
 * OBJECT(S) WHERE USED: TBD
 * DESCRIPTION: Allows for puzzles in rooms to be solved.
 */

public class SolvePuzzle : MonoBehaviour
{
    public Sprite slotSprite;

    private GameController gameController;
    private int roomNumber;
    private int itemsNeeded;
    private int itemsFound;
    private int[] whichListItem = new int[2];
    private int whichListItemIndex;
    private int inventoryListIndex;

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameController = GameObject.Find("game_controller").GetComponent<GameController>();

            // Gets active scene name and sets appropriate number based on it.
            switch (SceneManager.GetActiveScene().name)
            {
                case "bathroom":
                    roomNumber = 1;
                    break;
                case "playground":
                    roomNumber = 2;
                    break;
                case "math":
                    roomNumber = 3;
                    break;
                case "gym":
                    roomNumber = 4;
                    break;
                case "lobbyOne":
                    roomNumber = 5;
                    break;
                case "music":
                    roomNumber = 6;
                    break;
                case "lobbyTwo":
                    roomNumber = 7;
                    break;
                case "principals":
                    roomNumber = 8;
                    break;
                case "science":
                    roomNumber = 9;
                    break;
                case "astronomy":
                    roomNumber = 10;
                    break;
            }

            itemsNeeded = gameController.roomNeeds[roomNumber - 1].Length;
            Debug.Log("[SolvePuzzle] Items needed: " + itemsNeeded);

            whichListItem[0] = 0;
            whichListItem[1] = 0;
            whichListItemIndex = 0;
            inventoryListIndex = 0;
            itemsFound = 0;

            foreach (string nameOfIt in gameController.roomNeeds[roomNumber - 1])
            {
                inventoryListIndex = 0;

                foreach (Item anItem in GameController.inventoryList)
                {
                    if (anItem.itemName == nameOfIt)
                    {
                        Debug.Log("Found and matched item \"" + anItem.itemName + "\" in inventory at: " + inventoryListIndex);
                        whichListItem[whichListItemIndex] = inventoryListIndex;
                        whichListItemIndex++;
                        itemsFound++;
                        break;
                    }

                    inventoryListIndex++;
                }
            }

            Debug.Log("whichListItem[0]: " + whichListItem[0] + "\nwhichListItem[1]: " + whichListItem[1]);
            Debug.Log("itemsNeeded: " + itemsNeeded + "\nitemsFound: " + itemsFound);

            if (itemsNeeded == itemsFound)
            {
                Debug.Log("Pre-Removal InventoryList Count: " + GameController.inventoryList.Count);

                for (int i = 0; i < itemsNeeded; i++)
                {
                    // Move the items from the inventoryList to inventoryUsed
                    Debug.Log("InventoryList[" + whichListItem[i] + "]");
                    GameController.inventoryUsed.Add(GameController.inventoryList[whichListItem[i]]);
                    GameController.inventoryList.RemoveAt(whichListItem[i]);

                    // Reloads the HUD.
                    for (int j = 0; j < 12; j++)
                    {
                        GameObject.Find("slot_" + j).GetComponent<Image>().sprite = slotSprite;
                    }

                    int slotNumber = 1;

                    foreach (Item anItem in GameController.inventoryList)
                    {
                        Texture2D tex;
                        Sprite mySprite;
                        GameObject anObject = GameObject.Find("slot_" + slotNumber);
                        tex = anItem.itemIcon;
                        mySprite = Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(.5f, .5f));
                        anObject.GetComponent<Image>().sprite = mySprite;
                        slotNumber++;
                    }
                }

                Debug.Log("Post-Removal InventoryList Count: " + GameController.inventoryList.Count);
            }
        }
    }
}
