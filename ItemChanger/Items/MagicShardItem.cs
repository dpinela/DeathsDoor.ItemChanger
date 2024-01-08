namespace DDoor.ItemChanger;

internal class MagicShardItem : Item
{
    private MagicShardItem() {}

    public static readonly MagicShardItem Instance = new();

    public string DisplayName => "Magic Shard";

    public string Icon => "MagicShard";

    public void Trigger()
    {
        var save = GameSave.GetSaveData();
        save.AddToCountKey("arrow_shard_total");
        var shards = save.GetCountKey("arrow_shard") + 1;
        if (shards >= 4)
        {
            shards = 0;
            save.AddToCountKey("arrow_shard_complete");
            // from Item_HeartContainer.giveExtraStats
            save.AddToCountKey("extra_arrow_charges");
            WeaponSwitcher.instance.Refresh();
            UIArrowChargeBar.instance.SetMaxChargeDelayed();
        }
        save.SetCountKey("arrow_shard", shards);
    }
}