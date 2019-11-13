using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject someObject;
    
    private int theOne = -1;

    private void OnTriggerStay(Collider col)
    {
        someObject = col.gameObject;

        if (someObject.tag == "pickup" && Input.GetKeyDown(KeyCode.E) && GameController.max != GameController.inventoryList.Count)
        {
            // Disables the mesh renderer if object is interactable.
            someObject.GetComponent<MeshRenderer>().enabled = false;
            //theOne = -1; (disabled)

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

                break;
            }
        }

        // If the item is not in inventory, add it.
        if (!foundIt)
        {
            AddItemToInventory(GameController.theItems[theOne]);
            //ShowInPanel();
        }
    }

    // Copy the given item into inventoryList.
    public void AddItemToInventory(Item item)
    {
        Item newItem = new Item(item.itemID, item.itemName, item.itemUsable);
        newItem.itemIcon = Resources.Load<Texture2D>("Sprites/" + newItem.itemName);
        GameController.inventoryList.Add(newItem);
        Debug.Log(newItem.itemName + " was added to inventory");
    }

    /*
    public void ShowInPanel()
    {
        Texture2D tex;
        Sprite mySprite;
        string theName;
        int whichOne;

        whichOne = GameController.inventoryList.Count;
        theName = "slot_" + whichOne;
        GameObject anObject = GameObject.Find(theName);
        tex = GameController.inventoryList[whichOne - 1].itemIcon;
        mySprite = Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(.5f, .5f));
        anObject.GetComponent<Image>().sprite = mySprite;
    }
    */
}
