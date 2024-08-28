namespace DDoor.ItemChanger;

internal class LoggedItem : Item
{
    private Item Item;
    private string What;
    private string Where;

    public LoggedItem(Item item, string itemName, string location)
    {
        Item = item;
        What = itemName;
        Where = location;
    }

    public string DisplayName => Item.DisplayName;

    public string Icon => Item.Icon;

    public void Trigger()
    {
        SaveData.Open().AddToTrackerLog(new TrackerLogEntry
        {
            ItemName = What,
            ItemDisplayName = Item.DisplayName,
            ItemIcon = Item.Icon,
            LocationName = Where,
            GameTime = GameTimeTracker.instance.GetTime()
        });
        Item.Trigger();
    }
}
