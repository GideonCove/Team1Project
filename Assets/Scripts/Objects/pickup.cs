using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Seth, Cameron, Gideon, Zach, Anthony
 * DATE OF CREATION: 10/23/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: all objects that can be picked up
 * DESCRIPTION: Allows the player to press "E" to pickup a highlighted(?) object and add it to their inventory.
 */

public class Pickup : MonoBehaviour
{
    // Imports the playerMovement script to keep track of inventory.
    private bool isThere = false;

    private void OnTriggerStay(Collider player)
    {
        // Assigns the specific script of the player's.
        // script = player.GetComponent<playerMovement>();

        // If the object is able to be picked up and "E" is pressed...
        if (gameObject.CompareTag("pickup") && Input.GetKeyDown(KeyCode.E))
        {

            // Checks to ensure the item picked up is not already in their inventory.
            for (int i = 0; i < playerMovement.inventory.Length; i++)
            {
                if (playerMovement.inventory[i] == gameObject)
                {
                    isThere = true;
                    break;
                }
            }

            // If the item picked up is not already in inventory, add it.
            if (!isThere)
            {
                AddObject(gameObject);
            }
        }
    }

    public void AddObject(GameObject itemToAdd)
    {
        bool itemAdded = false;

        // Looks for empty space in the inventory at add the item. If there is none, abort the process.
        for (int i = 0; i < playerMovement.inventory.Length; i++)
        {
            if (playerMovement.inventory[i] == null)
            {
                playerMovement.inventory[i] = itemToAdd;
                itemAdded = true;
                Debug.Log(itemToAdd.name + " was added to inventory");
                
                // Disables the mesh renderer.
                gameObject.GetComponent<MeshRenderer>().enabled = false;

                break;
            }
        }

        if (!itemAdded)
        {
            Debug.Log(itemToAdd.name + " could not be added to inventory");
        }
    }
}
