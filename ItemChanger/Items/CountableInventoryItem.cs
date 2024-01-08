namespace DDoor.ItemChanger;

internal class CountableInventoryItem : Item
{
    public string UniqueId { get; set; } = "";

    public string CountId { get; set; } = "";

    public string DisplayName { get; set; } = "";

    public string Icon { get; set; } = "Seed";

    public void Trigger()
    {
        Inventory.instance.AddItem(UniqueId);
        GameSave.GetSaveData().IncreaseCountKey(CountId);
    }
}