using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class InventoryManager : MonoBehaviour, IContentIO
{

    public static InventoryManager _instance;

    //Refference to the current Inventory
    public Inventory inventory;


    //List of all the Item in the Game
    //Drag and Drop your scriptable object here
    public InventoryItemList itemsList;
    public InventoryItemIconsList iconsList;

    //UI Reference
    public InventoryUIListGenerator UI;

    private void Awake()
    {
        #region Make Singleton
        //Check if instance already exists
        if (_instance == null)

            //if not, set instance to this
            _instance = this;

        //If instance already exists and it's not this:
        else if (_instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        #endregion



        // Set the Inventory State


        if (PlayerPrefs.GetInt("InventoryInitialized", 0) != 0)
        {
            Load();
        }
        else
        {
            SetInventoryInitState(true);
            Save();
        }
    }



    private void Start()
    {
        //GiveStartingItems();
        //GiveStartingItems();
        //GiveStartingItems();
        //GiveStartingItems();
        //GiveStartingItems();
        //GiveStartingItems();

    }




    #region PublicMethods

    /// <summary>
    /// Adds starting items to your inventory
    /// </summary>
    public void GiveStartingItems()
    {
        foreach (Item item in itemsList.itemList)
        {
            AddItem(item.ID);
        }
    }


    /// <summary>
    /// Adds an Item in the Inventory List
    /// </summary>
    /// <param name="ID">Unique ID of the Item</param>
    public void AddItem(int ID)
    {
        inventory.inventoryItems.Add(itemsList.GetItemByID(ID));
    }

    /// <summary>
    /// Removes an Item in the Inventory List
    /// </summary>
    /// <param name="ID">Unique ID of the Item</param>
    public void RemoveItem(int ID)
    {
        Debug.Log("Removing Item: " + GetItem(ID).Name);
        //inventory.inventoryItems.Remove(itemsList.GetItemByID(ID));
        DeleteItem(ID, inventory.inventoryItems);
    }

    /// <summary>
    /// Delete's item from List (Custom Logic)
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="items"></param>
    private void DeleteItem(int ID, List<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID.Equals(ID))
            {
                items.RemoveAt(i);
                break;
            }
        }
    }

    /// <summary>
    /// Checks the Inventory for whether and Item is present or not
    /// </summary>
    /// <param name="ID">Unique ID of the Item</param>
    /// <returns></returns>
    public bool HasItem(int ID)
    {
        bool hasItem = true;

        for (int i = 0; i < inventory.inventoryItems.Count; i++)
        {
            if (inventory.inventoryItems[i].ID == ID)
            {
                hasItem = true;
                break;
            }
            else
            {
                hasItem = false;
                continue;
            }
        }

        return hasItem;

        //if (inventory.inventoryItems.Contains(itemsList.GetItemByID(ID)))
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }

    /// <summary>
    /// Returns the Item Specified by ID in the Inventory
    /// </summary>
    /// <param name="ID">Unique Identifier of the Item</param>
    /// <returns></returns>
    public Item GetItem(int ID)
    {
        Item _item = null;
        for (int i = 0; i < itemsList.itemList.Length; i++)
        {
            if (itemsList.itemList[i].ID.Equals(ID))
            {
                _item = itemsList.itemList[i];
                break;
            }
        }
        if (_item == null)
            Debug.LogError("Requested Item ID not in List");
        return _item;

    }

    public Sprite GetIcon(int ID)
    {
        Sprite icon = null;
        for (int i = 0; i < iconsList.itemList.Length; i++)
        {
            if (iconsList.itemList[i].ID.Equals(ID))
            {
                icon = iconsList.itemList[i].Icon;
                break;
            }
        }
        if (icon == null)
            Debug.LogError("Requested Item ID not in List");
        return icon;


    }

    #endregion

    private void SetInventoryInitState(bool isInitialized)
    {
        if (isInitialized)
        {
            PlayerPrefs.SetInt("InventoryInitialized", 1);
        }
        else
        {
            PlayerPrefs.SetInt("InventoryInitialized", 0);
        }
        PlayerPrefs.Save();
    }


    /// <summary>
    /// Saves Inventory to File
    /// </summary>
    public void Save()
    {
        //SaveGame.Save("GameInventory", inventory.inventoryItems);

        XMLSAVESYSTEM.Save<List<Item>>(inventory.inventoryItems, "InventoryItemsDB");
    }

    /// <summary>
    /// Loads Inventory from File
    /// </summary>
    public void Load()
    {
        //inventory.inventoryItems = SaveGame.Load<List<Item>>("GameInventory");

        inventory.inventoryItems = XMLSAVESYSTEM.Load<List<Item>>(inventory.inventoryItems, "InventoryItemsDB");
    }

    /// <summary>
    /// Deletes Inventory File
    /// </summary>
    public void Clear()
    {
        //SaveGame.Delete("GameInventory");

        XMLSAVESYSTEM.Delete("InventoryItemsDB");

        SetInventoryInitState(false);
    }


}
