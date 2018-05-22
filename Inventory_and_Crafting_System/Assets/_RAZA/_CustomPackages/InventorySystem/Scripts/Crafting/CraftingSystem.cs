using UnityEngine;

public class CraftingSystem : MonoBehaviour
{

    //Singleton Refference
    public static CraftingSystem _instance;
    //Selected Item
    private Item selectedItem;

    public CraftingSystemUIListGenerator UI;

    //Drag and Drop your scriptable object here
    public InventoryItemList itemsList;
    public InventoryItemIconsList iconsList;

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
    }


    /// <summary>
    /// Sets Inventory Systems "SELECTED ITEM"
    /// </summary>
    /// <param name="ID">Unique Identifier of the Item</param>
    public void SetSelectedItem(int ID)
    {
        selectedItem = InventoryManager._instance.GetItem(ID);
    }

    /// <summary>
    /// Checks the Inventory for Required Items
    /// </summary>
    /// <returns>True if Inventory has the Required Items: False if Not</returns>
    public bool HasRequiredItems()
    {
        //Initially set to True
        bool hasRequiredItems = true;

        for (int i = 0; i < selectedItem.requiredItems.Length; i++)
        {
            if (!(InventoryManager._instance.HasItem(selectedItem.requiredItems[i])))
            {
                Debug.Log("Does Not Have Required Items for Crafting");
                hasRequiredItems = false;
                break;
            }
        }

        return hasRequiredItems;
    }


    /// <summary>
    /// Returns the Main Selected Item in the Crafting System
    /// </summary>
    /// <returns>Item Selected</returns>
    public Item GetSelectedItem()
    {
        return InventoryManager._instance.GetItem(selectedItem.ID);
    }

    /// <summary>
    /// Crafts the selected Item
    /// </summary>
    public void CraftItem()
    {
        //Check to see if the required items are present
        if (selectedItem.requiredItems.Length > 0)
        {
            if (HasRequiredItems())
            {
                //Add the selected Item in the Inventory
                InventoryManager._instance.AddItem(selectedItem.ID);

                //Remove the consumed items from the Inventory
                for (int i = 0; i < selectedItem.requiredItems.Length; i++)
                {
                    InventoryManager._instance.RemoveItem(selectedItem.requiredItems[i]);
                }
            }

            //UpdateInventory
            if (InventoryManager._instance.UI)
            {
                InventoryManager._instance.UI.GenerateInvnetoryList();
            }
            else
            {
                Debug.LogError("InventoryManager UI Refference not Found");
            }
        }

        UI.IsCraftable();
        InventoryManager._instance.Save();
    }


}
