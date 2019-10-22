using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    // Decides whether or not this can be picked up.
    public bool canPickup = false;

    playerMovement script;
    private bool isThere = false;

    private void OnTriggerStay(Collider player)
    {
        script = player.GetComponent<playerMovement>();

        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            // Disables the mesh renderer.
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            for (int i = 0; i < script.inventory.Length; i++)
            {
                if (script.inventory[i] == gameObject)
                {
                    isThere = true;
                    break;
                }
            }

            if (!isThere)
            {
                AddObject(gameObject);
            }
        }
    }

    public void AddObject(GameObject itemToAdd)
    {
        bool itemAdded = false;

        for (int i = 0; i < script.inventory.Length; i++)
        {
            if (script.inventory[i] == null)
            {
                script.inventory[i] = itemToAdd;
                itemAdded = true;
                Debug.Log(itemToAdd.name + "was added to inventory");

                break;
            }
        }

        if (!itemAdded)
        {
            Debug.Log(itemToAdd.name + "could not be added to inventory");
        }
    }
}
