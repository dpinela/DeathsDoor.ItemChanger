namespace DDoor.ItemChanger;

internal class VitalityShardItem : Item
{
    public static readonly VitalityShardItem Instance = new();

    public string DisplayName => Amount == 1 ? "Vitality Shard" : $"{Amount} Vitality Shards";

    public string Icon => "VitalityShard";

    public int Amount = 1;

    public void Trigger()
    {
        var save = GameSave.GetSaveData();
        save.AddToCountKey("heart_shard_total");
        var shards = save.GetCountKey("heart_shard") + Amount;
        if (shards >= 4)
        {
            var heartsAdded = shards / 4;
            shards %= 4;
            save.AddToCountKey("heart_shard_complete", heartsAdded);
            // from Item_HeartContainer.giveExtraStats
            UIHealthEnergyBar.instance.SetPermanentHP(UIHealthEnergyBar.instance.GetMaxHealth() + 1);
        }
        save.SetCountKey("heart_shard", shards);
    }
}