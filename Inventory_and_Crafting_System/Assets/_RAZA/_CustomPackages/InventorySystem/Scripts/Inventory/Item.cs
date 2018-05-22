[System.Serializable]
public class Item
{
    public enum ItemTier { Common, Uncommon, Rare, Legendary, Mythical, Immortal };
    public enum ItemCategory { Food, Potions, Parts };


    //Name of the Item
    public string Name;
    //Unique Identifier for the Item
    public int ID;
    //Price of the Item
    public int Price;
    //Item Tier Value
    //Can be used for Sorting and Pricing in Vendor Shop
    public ItemTier tier;

    //public ItemCategory category;

    //Required Components for Crafting ~If Any
    public int[] requiredItems;
}
