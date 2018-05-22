using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUIListGenerator : MonoBehaviour
{

    //public static InventoryUIListGenerator _instance;

    public GameObject ScrollList;
    public GameObject SlotPrefab;



    public void GenerateInvnetoryList()
    {
        ClearInventoryList();


        if (!InventoryManager._instance)
        {
            Debug.Log("InventoryINSTANCE");
            if (!InventoryManager._instance.inventory)
            {
                Debug.Log("INTANCE.INVENTORYNULL");
                if (!(InventoryManager._instance.inventory.inventoryItems != null))
                {
                    Debug.Log("InventoryITemsNULL");
                }
            }
        }

        List<Item> tempInventory = InventoryManager._instance.inventory.inventoryItems;

        if (tempInventory == null)
        {
            Debug.LogError("Inventory is Empty");
        }
        else
        {
            List<int> populatedItems = new List<int>();



            int uniqueItems = (from n in tempInventory
                               group n by n.ID into m
                               select m
                               ).Count();

            Debug.Log("Unique Items: " + uniqueItems);

            for (int i = 0; i < tempInventory.Count; i++)
            {
                if (!HasPopulated(tempInventory[i].ID, populatedItems))
                {
                    //Debug.Log("Pushing: " + tempInventory[i].ID);
                    //Push the item in the populated List
                    populatedItems.Add(tempInventory[i].ID);

                    int itemCount = (from n in tempInventory
                                     where n.ID == tempInventory[i].ID
                                     select n).Count();
                    //Debug.Log("count: " + itemCount);

                    GameObject slot = Instantiate(SlotPrefab) as GameObject;
                    slot.transform.SetParent(ScrollList.transform);

                    InventorySlot tempSlot = slot.GetComponent<InventorySlot>();

                    tempSlot.icon.sprite = InventoryManager._instance.GetIcon(tempInventory[i].ID);
                    tempSlot.itemCount.text = "X" + itemCount.ToString();
                    tempSlot.ID = tempInventory[i].ID;

                    slot.transform.localScale = Vector3.one;
                }
            }
        }
    }

    private void ClearInventoryList()
    {
        foreach (Transform item in ScrollList.transform)
        {
            GameObject.Destroy(item.gameObject);
        }
    }

    private bool HasPopulated(int ID, List<int> populatedList)
    {
        bool hasPopulated = false;
        for (int i = 0; i < populatedList.Count; i++)
        {
            if (populatedList[i] == ID)
            {
                hasPopulated = true;
                break;
            }
        }
        return hasPopulated;
    }
}
