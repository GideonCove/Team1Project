using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
 * AUTHOR(S): Seth, Cameron, Gideon, Zach, Anthony
 * DATE OF CREATION: 11/21/2019
 * SCENE(S) WHERE USED: ALL 
 * OBJECT(S) WHERE USED: TBD
 * DESCRIPTION: Allows for puzzles in rooms to be solved.
 */

public class SolvePuzzle : MonoBehaviour
{
    public Sprite slotSprite;
    public GameObject solveText;
    public GameObject dropItem;
    public string dropItemName;
    public GameObject soulModel;
    public string type;
    public bool secondary = false;

    private GameController gameController;
    private int roomNumber;
    private int itemsNeeded;
    private int itemsFound;
    private int[] whichListItem = new int[2];
    private int whichListItemIndex;
    private int inventoryListIndex;
    public static bool padlockUnlocked = false;
    public static bool principalUnlocked = false;
    public static bool planetsSolved = false;

    private void Awake()
    {
        solveText.SetActive(false);

        if ((principalUnlocked && SceneManager.GetActiveScene().name == "lobbyOne") || (padlockUnlocked && SceneManager.GetActiveScene().name == "playground"))
        {
            gameObject.GetComponent<Door>().locked = false;
            Destroy(gameObject.GetComponent<SolvePuzzle>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (((SceneManager.GetActiveScene().name == "lobbyOne" && !principalUnlocked) || (SceneManager.GetActiveScene().name == "playground" && !padlockUnlocked)) && gameObject.tag == "door")
        {
            solveText.GetComponent<Text>().text = "[\"SPACE\" to unlock]";
        }
        else
        {
            solveText.GetComponent<Text>().text = "[\"SPACE\" to interact]";
        }
    }

    public void OnTriggerStay(Collider other)
    {
        solveText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
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

            if (!secondary)
            {
                itemsNeeded = gameController.roomNeedsPrimary[roomNumber - 1].Length;
                Debug.Log("[SolvePuzzle] Items needed: " + itemsNeeded);

                whichListItem[0] = 0;
                whichListItem[1] = 0;
                whichListItemIndex = 0;
                inventoryListIndex = 0;
                itemsFound = 0;

                foreach (string nameOfIt in gameController.roomNeedsPrimary[roomNumber - 1])
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
            }

            // If no items found in primary puzzle array, try the secondary one.
            if (secondary)
            {
                itemsNeeded = gameController.roomNeedsSecondary[roomNumber - 1].Length;
                Debug.Log("[SolvePuzzle] Items needed: " + itemsNeeded);

                whichListItem[0] = 0;
                whichListItem[1] = 0;
                whichListItemIndex = 0;
                inventoryListIndex = 0;
                itemsFound = 0;

                foreach (string nameOfIt in gameController.roomNeedsSecondary[roomNumber - 1])
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
            }

            int whichTemp = whichListItem[0];
            if (whichListItem[1] > whichListItem[0])
            {
                whichListItem[0] = whichListItem[1];
                whichListItem[1] = whichTemp;
            }

            Debug.Log("whichListItem[0]: " + whichListItem[0] + "\nwhichListItem[1]: " + whichListItem[1]);
            Debug.Log("itemsNeeded: " + itemsNeeded + "\nitemsFound: " + itemsFound);

            if (itemsNeeded == itemsFound)
            {
                Debug.Log("Pre-Removal InventoryList Count: " + GameController.inventoryList.Count);

                for (int i = 0; i < itemsNeeded; i++)
                {
                    // Move the items from the inventoryList to inventoryUsed.
                    Debug.Log("InventoryList[" + whichListItem[i] + "]: " + GameController.inventoryList[whichListItem[i]].itemName);
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
                        GameObject anObject = GameObject.Find("slot_" + (slotNumber - 1));
                        tex = anItem.itemIcon;
                        mySprite = Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(.5f, .5f));
                        anObject.GetComponent<Image>().sprite = mySprite;
                        slotNumber++;
                    }

                    Destroy(gameObject.GetComponent<SolvePuzzle>());
                }

                Debug.Log("Post-Removal InventoryList Count: " + GameController.inventoryList.Count);

                // If the puzzle releases a soul, subtract from counter and add time.
                if (type == "soul")
                {
                    Timer.soulsRemaining--;
                    Timer.currentTime += 3 * 60;

                    // Spawn a soul prefab that has a script attached.
                    GameObject soul = GameObject.Instantiate(soulModel, new Vector3 (gameObject.transform.position.x, -1, gameObject.transform.position.z), new Quaternion(0, 0, 0, 0));

                    // Do specific soul action based on room if necessary.
                    switch (SceneManager.GetActiveScene().name)
                    {
                        case "music":
                            // Drop padlock key.
                            GameObject key = GameObject.Instantiate(dropItem, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), new Quaternion(0, 0, 0, 0));
                            key.name = dropItemName;
                            break;

                        case "playground":
                            // Fix merry-go-round.
                            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                            MGRCheck.mgrSolved = true;
                            break;

                        case "math":
                            // Drop pluto.
                            GameObject pluto = GameObject.Instantiate(dropItem, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), new Quaternion(0, 0, 0, 0));
                            pluto.name = dropItemName;
                            break;

                        case "astronomy":
                            // Drop locker combo.
                            GameObject combo = GameObject.Instantiate(dropItem, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), new Quaternion(0, 0, 0, 0));
                            combo.name = dropItemName;
                            planetsSolved = true;
                            break;

                        case "principals":
                            GameController.gameOverOver = true;
                            GameController.gameOverReason = "You saved your sister and escaped the school! Congrats!";
                            SceneManager.LoadScene("principals");
                            break;
                    }
                }

                // If the type is item, spawns the item.
                if (type == "item")
                {
                    switch (SceneManager.GetActiveScene().name)
                    {
                        case "playground":
                            gameObject.GetComponent<Door>().locked = false;
                            solveText.GetComponent<Text>().text = "[\"SPACE\" to open]";
                            padlockUnlocked = true;
                            break;

                        case "lobbyOne":
                            if (gameObject.tag == "door")
                            {
                                gameObject.GetComponent<Door>().locked = false;
                                solveText.GetComponent<Text>().text = "[\"SPACE\" to open]";
                                principalUnlocked = true;
                            }
                            else
                            {
                                // Do item spawn
                                GameObject key = GameObject.Instantiate(dropItem, other.gameObject.transform.position, new Quaternion(0, 0, 0, 0));
                                key.name = dropItemName;
                            }
                            break;

                        default:
                            // Do item spawn
                            GameObject item = GameObject.Instantiate(dropItem, other.gameObject.transform.position, new Quaternion(0, 0, 0, 0));
                            item.name = dropItemName;
                            break;
                    }
                }
                
                solveText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        solveText.SetActive(false);
    }
}
