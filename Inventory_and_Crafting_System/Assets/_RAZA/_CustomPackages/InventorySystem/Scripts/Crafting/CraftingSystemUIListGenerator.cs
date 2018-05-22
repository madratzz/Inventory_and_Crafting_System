using UnityEngine;
using UnityEngine.UI;

public class CraftingSystemUIListGenerator : MonoBehaviour
{

    public GameObject ScrollList;
    public GameObject RequirementsList;
    public GameObject SlotPrefab;

    public Button CraftButton;

    public void GenerateCraftingList()
    {
        ClearInventoryList();

        Item[] tempInventory = CraftingSystem._instance.itemsList.itemList;

        for (int i = 0; i < tempInventory.Length; i++)
        {
            if (tempInventory[i].requiredItems.Length == 0)
            {
                continue;
            }
            GameObject slot = Instantiate(SlotPrefab) as GameObject;
            slot.transform.SetParent(ScrollList.transform);
            InventorySlot tempSlot = slot.GetComponent<InventorySlot>();
            tempSlot.icon.sprite = InventoryManager._instance.GetIcon(tempInventory[i].ID);
            tempSlot.ID = tempInventory[i].ID;
            tempSlot.icon.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            tempSlot.itemCount.text = null;
            slot.transform.localScale = Vector3.one;

            //AddButtonCallBack
            tempSlot.gameObject.GetComponent<Button>().onClick.AddListener(tempSlot.PopulateRequirements);
        }
    }

    public void GenerateRequirementsList()
    {
        ClearRequirementList();
        Item SelectedItem = CraftingSystem._instance.GetSelectedItem();

        IsCraftable();

        for (int i = 0; i < SelectedItem.requiredItems.Length; i++)
        {
            GameObject slot = Instantiate(SlotPrefab) as GameObject;
            slot.transform.SetParent(RequirementsList.transform);
            InventorySlot tempSlot = slot.GetComponent<InventorySlot>();



            tempSlot.icon.sprite = InventoryManager._instance.GetIcon(SelectedItem.requiredItems[i]);
            tempSlot.ID = SelectedItem.requiredItems[i];

            tempSlot.icon.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            tempSlot.itemCount.text = null;

            slot.transform.localScale = Vector3.one;
        }
    }

    public void IsCraftable()
    {
        Item SelectedItem = CraftingSystem._instance.GetSelectedItem();

        //Debug.Log("Has REQ Items: " + CraftingSystem._instance.HasRequiredItems());

        if (SelectedItem.requiredItems.Length == 0)
        {
            CraftButton.interactable = false;
        }
        else if (!CraftingSystem._instance.HasRequiredItems())
        {
            CraftButton.interactable = false;
        }
        else
        {
            CraftButton.interactable = true;
        }
    }

    private void ClearInventoryList()
    {
        foreach (Transform item in ScrollList.transform)
        {
            GameObject.Destroy(item.gameObject);
        }
    }

    private void ClearRequirementList()
    {
        foreach (Transform item in RequirementsList.transform)
        {
            GameObject.Destroy(item.gameObject);
        }
    }
}
