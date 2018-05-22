using UnityEngine;

[CreateAssetMenuAttribute(fileName = "NewItemsList", menuName = "InventorySystem/ItemsList")]
public class InventoryItemList : ScriptableObject
{

    public Item[] itemList;


    /// <summary>
    /// Returns and item of the Desired ID from a list of items
    /// </summary>
    /// <param name="ID">Unique ID for the Item</param>
    /// <returns></returns>
    public Item GetItemByID(int ID)
    {
        foreach (Item item in itemList)
        {
            if (item.ID.Equals((ID)))
            {
                return item;
            }
        }

        //If we are down to this line it means no item was found and
        //we should return null
        return null;
    }
}



