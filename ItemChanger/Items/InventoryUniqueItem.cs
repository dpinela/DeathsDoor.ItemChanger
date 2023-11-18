namespace DDoorItemChanger;

internal class InventoryUniqueItem : Item
{
    public string DisplayName { get; set; } = "";

    public string ItemId { get; set; } = "";

    public void Trigger()
    {
        Inventory.instance.AddItem(ItemId);
    }
}