using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
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
