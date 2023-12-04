namespace DeathsDoor.ItemChanger;

internal class GiantSoulItem : Item
{
    public string DisplayName { get; set; } = "";

    public string ItemId { get; set; } = "";

    public void Trigger()
    {
        Inventory.instance.AddItem(ItemId);
        GameSave.GetSaveData().IncreaseCountKey("boss_souls");
    }
}