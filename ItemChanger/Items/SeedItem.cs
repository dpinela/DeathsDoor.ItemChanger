namespace DDoor.ItemChanger;

internal class SeedsItem : Item
{
    public int Amount = 1;

    public string DisplayName => Amount == 1 ? "Life Seed" : $"{Amount} Life Seeds";

    public string Icon => "Seed";

    public void Trigger()
    {
        GameSave.GetSaveData().AddToCountKey("seed_total_collected");
        Inventory.instance.AddItem("seed", Amount);
        UICount.Show("SEEDS", 1);
    }
}