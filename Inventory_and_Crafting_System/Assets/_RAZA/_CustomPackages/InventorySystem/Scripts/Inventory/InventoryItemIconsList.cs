using UnityEngine;

[CreateAssetMenuAttribute(fileName = "NewIconsList", menuName = "InventorySystem/ItemsIconList")]
public class InventoryItemIconsList : ScriptableObject
{
    public UIItem[] itemList;
}
