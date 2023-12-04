namespace DeathsDoor.ItemChanger;

internal class SeedItem : Item
{
    private SeedItem() {}

    public static readonly SeedItem Instance = new();

    public string DisplayName => "Life Seed";

    public void Trigger()
    {
        GameSave.GetSaveData().AddToCountKey("seed_total_collected");
        Inventory.instance.AddItem("seed", 1);
        UICount.Show("SEEDS", 1);
    }
}