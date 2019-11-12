using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * AUTHOR(S): Seth, Cameron, Gideon, Zach, Anthony
 * DATE OF CREATION: 10/9/2019
 * SCENE(S) WHERE USED: ALL
 * OBJECT(S) WHERE USED: game_controller
 * DESCRIPTION: Holds important global variables for use in-game.
 */


public class GameController : MonoBehaviour
{

    // Create the singleton
    public static GameController instance;

    // This is the list that holds invenotry for the game
    public static List<Item> inventoryList = new List<Item>();

    // A list of items that have been used to solve puzzles
    public static List<Item> inventoryUsed = new List<Item>();

    // These are the items in the game that are collectible
    public static List<Item> theItems = new List<Item>();

    public string filePath = "Sprites/";
    private Sprite[] sprites;
    private string msg = "Images Loaded: ";

    // Set up the sprites using the dictionary.
    public Dictionary<string, string> spriteDictionary = new Dictionary<string, string>();
    public TextAsset dataFile;
    public string[] dataLines;
    public string[][] dataPairs;

    private void Start()
    {
        // This adds to the itemDatabase using the Item class constructor we created in item.cs

        foreach (Item anItem in theItems)
        {
            anItem.itemIcon = Resources.Load<Texture2D>(filePath + anItem.itemName);
        }
    }

    /*private void Awake()
    {
        // Loading sprites into array using the Resources directory.
        sprites = Resources.LoadAll<Sprite>(filePath);
        msg += sprites.Length;
        Debug.Log(msg);

        // Load the dictionary.
        dataFile = Resources.Load("spriteDictionary") as TextAsset;
        dataLines = dataFile.text.Split('\n');
        dataPairs = new string[dataLines.Length][];

        int lineNum = 0;

        foreach (string line in dataLines)
        {
            dataPairs[lineNum++] = line.Split(':');
            string[] aPart = line.Split(':');

            if (aPart[0] == "")
            {
                break;
            }
            else
            {
                spriteDictionary.Add(aPart[0], aPart[1]);
            }
        }

        // Verify the dictionary loaded.
        Debug.Log("Entries in dictionary: " + spriteDictionary.Count);

        foreach (KeyValuePair<string, string> keyValue in spriteDictionary)
        {
            Debug.Log("key, value: " + keyValue.Key + ":" + keyValue.Value);
        }
    }
    */
}
