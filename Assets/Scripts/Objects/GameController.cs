using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private static bool initialLoad = true;

    // Settings variables
    public static float brightness = 10;
    public static float speed = 10;

    // This is the list that holds invenotry for the game
    public static List<Item> inventoryList = new List<Item>();
    public static int max = 12;

    // A list of items that have been used to solve puzzles
    public static List<Item> inventoryUsed = new List<Item>();

    // These are the items in the game that are collectible
    public static List<Item> theItems = new List<Item>();

    public string filePath = "Sprites/Items";
    private Sprite[] sprites;
    private string msg = "Images Loaded: ";

    // Set up the sprites using the dictionary.
    public Dictionary<string, string> spriteDictionary = new Dictionary<string, string>();
    public TextAsset dataFile;
    public string[] dataLines;
    public string[][] dataPairs;

    // Sets up what rooms need which items.
    public string[][] roomNeeds = new string[][]
    {
        new string[0] { },
        new string[0] { },
        new string[0] { },
        new string[1] {"loose_basketball"},
        new string[0] { },
        new string[0] { },
        new string[0] { },
        new string[0] { },
        new string[0] { },
        new string[0] { }
    };

    private void Awake()
    {
        if (GameObject.Find("game_controller") && !initialLoad)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        // Loading sprites into array using the Resources directory.
        sprites = Resources.LoadAll<Sprite>(filePath);
        msg += sprites.Length;
        Debug.Log(msg);

        // This adds to the itemDatabase using the Item class constructor we created in item.cs
        theItems.Add(new Item(0, "loose_basketball", true));
        theItems.Add(new Item(1, "calculator", true));
        theItems.Add(new Item(2, "dumbbell", true));
        theItems.Add(new Item(3, "loose_screw", true));
        theItems.Add(new Item(4, "ocarina", true));
        theItems.Add(new Item(5, "padlock_key", true));
        theItems.Add(new Item(6, "plunger", true));
        theItems.Add(new Item(7, "pluto", true));
        theItems.Add(new Item(8, "family_portrait", true));
        theItems.Add(new Item(9, "school_flag", true));
        theItems.Add(new Item(10, "whistle", true));

        foreach (Item anItem in theItems)
        {
            anItem.itemIcon = Resources.Load<Texture2D>(filePath + anItem.itemName);
        }

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

        initialLoad = false;
    }
}
