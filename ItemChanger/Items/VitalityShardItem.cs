namespace DeathsDoor.ItemChanger;

internal class VitalityShardItem : Item
{
    private VitalityShardItem() {}

    public static readonly VitalityShardItem Instance = new();

    public string DisplayName => "Vitality Shard";

    public void Trigger()
    {
        var save = GameSave.GetSaveData();
        save.AddToCountKey("heart_shard_total");
        var shards = save.GetCountKey("heart_shard") + 1;
        if (shards >= 4)
        {
            shards = 0;
            save.AddToCountKey("heart_shard_complete");
            // from Item_HeartContainer.giveExtraStats
            UIHealthEnergyBar.instance.SetPermanentHP(UIHealthEnergyBar.instance.GetMaxHealth() + 1);
        }
        save.SetCountKey("heart_shard", shards);
    }
}