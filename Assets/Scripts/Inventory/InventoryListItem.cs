// this is the class for the inventory list item
// it has an item and a quantity
[System.Serializable]

public class InventoryListItem
{
  public Item item;
  public int quantity;
  public InventoryListItem(Item item, int quantity)
  {
    this.item = item;
    this.quantity = quantity;
  }
}