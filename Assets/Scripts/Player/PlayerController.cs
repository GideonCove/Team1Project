using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
 * AUTHOR(S): Seth, Cameron, Gideon, Zach, Anthony
 * DATE OF CREATION: 11/12/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: player
 * DESCRIPTION: Allows for objects to be picked up and added to HUD.
 */

public class PlayerController : MonoBehaviour
{
    public GameObject someObject;

    private int theOne = -1;

    public static float destinationX = 0;
    public static float destinationY = 1;
    public static float destinationZ = 0;
    public static string destinationDirection;

    // Sets the player up in rooms
    private void Awake()
    {
        gameObject.transform.position = new Vector3(destinationX, destinationY, destinationZ);

        switch (destinationDirection)
        {
            case "north":
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                }
            case "south":
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                }
            case "east":
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
                    break;
                }
            case "west":
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                }
        }

        Debug.Log("Successful teleportation in scene " + SceneManager.GetActiveScene().name + " to: " + destinationX + ", " + destinationZ);
    }

    private void OnTriggerStay(Collider col)
    {
        someObject = col.gameObject;

        if (someObject.tag == "pickup" && Input.GetKeyDown(KeyCode.E))
        {
            // Disables the mesh renderer if object is interactable.
            someObject.GetComponent<MeshRenderer>().enabled = false;

            FindInDatabase();
            IsItHere();
        }
    }

    // Find the object collided with in the itemDatabase.
    private void FindInDatabase()
    {
        for (int i = 0; i < GameController.theItems.Count; i++)
        {
            // If the itemDatabase matches the name of the object collided with...
            if (GameController.theItems[i].itemName == someObject.name)
            {
                theOne = i;

                break;
            }
        }
    }

    // Make sure the item is added to inventory only once.
    private void IsItHere()
    {
        bool foundIt = false;

        // Compare values of the contents of the items in the lists.
        // CAUTION: list.contains will NOT do this as it looks for objects and not values.
        foreach (Item x in GameController.inventoryList)
        {
            if (x.itemName == someObject.name)
            {
                foundIt = true;
                Debug.Log("Found it!");

                break;
            }
        }

        // If the item is not in inventory, add it.
        if (!foundIt)
        {
            AddItemToInventory(GameController.theItems[theOne]);
            ShowInPanel();
        }
    }

    // Copy the given item into inventoryList.
    public void AddItemToInventory(Item item)
    {
        Item newItem = new Item(item.itemID, item.itemName, item.itemUsable);
        newItem.itemIcon = Resources.Load<Texture2D>("Sprites/Items/" + newItem.itemName);
        GameController.inventoryList.Add(newItem);
        Debug.Log(newItem.itemName + " was added to inventory");
    }

    
    public void ShowInPanel()
    {
        Texture2D tex;
        Sprite mySprite;
        string theName;
        int whichOne;

        whichOne = GameController.inventoryList.Count;
        theName = "slot_" + (whichOne - 1);
        GameObject anObject = GameObject.Find(theName);
        tex = GameController.inventoryList[whichOne - 1].itemIcon;
        mySprite = Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(1f, 1f));
        anObject.GetComponent<Image>().sprite = mySprite;

        if (GameController.inventoryList.Count == GameController.max)
        {
            GameController.gameOverReason = "You ran out of inventory space.";
            SceneManager.LoadScene("gameOver");
        }
    }
}
