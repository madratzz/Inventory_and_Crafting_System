using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    //Item Icon
    public Image icon;
    //Item Count Text Refference
    public Text itemCount;

    //Unique ID of Item
    public int ID;


    //Function Call 
    public void PopulateRequirements()
    {
        CraftingSystem._instance.SetSelectedItem(ID);
        CraftingSystem._instance.UI.GenerateRequirementsList();
    }

}
