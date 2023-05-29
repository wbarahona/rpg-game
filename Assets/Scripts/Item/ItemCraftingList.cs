// this script is used to list the materials needed to craft an item
// this script is used in the crafting menu

[System.Serializable]

public class ItemCraftingList
{
  public ItemMaterial material;
  public int quantity;
  public ItemCraftingList(ItemMaterial material, int quantity)
  {
    this.material = material;
    this.quantity = quantity;
  }
}