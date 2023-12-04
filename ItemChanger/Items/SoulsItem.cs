namespace DeathsDoor.ItemChanger;

internal class SoulsItem : Item
{
    public int Amount { get; set; } = 0;

    public string DisplayName => Amount == 1 ? "1 Soul" : $"{Amount} Souls";

    public void Trigger()
    {
        GameSave.GetSaveData().AddToCountKey("soul_bundles_collected");
        Inventory.instance.AddItem("currency", Amount);
        UICount.Show("SOULS", 1);
    }
}