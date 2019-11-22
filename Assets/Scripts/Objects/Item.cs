using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Seth
 * DATE OF CREATION: 11/12/2019
 * SCENE(S) WHERE USED: NONE
 * OBJECT(S) WHERE USED: NONE
 * DESCRIPTION: Allows for an Item class to be created for use within the inventory systems.
 */

public class Item
{
    public int itemID;
    public Texture2D itemIcon;
    public string itemName;
    public bool itemUsable;

    public Item(int id, string name, bool usable)
    {
        // Transfer values from construction to class variables.
        itemID = id;
        // itemIcon = Resources.Load<Texture2D>("Sprites/" + name);
        itemName = name;
        itemUsable = usable;

    }
}
