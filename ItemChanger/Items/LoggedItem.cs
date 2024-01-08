namespace DDoor.ItemChanger;

internal class LoggedItem : Item
{
    public Item Item;
    public string Where;

    public LoggedItem(Item item, string location)
    {
        Item = item;
        Where = location;
    }

    public string DisplayName => Item.DisplayName;

    public string Icon => Item.Icon;

    public void Trigger()
    {
        SaveData.Open().AddToTrackerLog(new TrackerLogEntry
        {
            ItemName = Item.DisplayName,
            ItemIcon = Item.Icon,
            LocationName = Where,
            GameTime = GameTimeTracker.instance.GetTime()
        });
        Item.Trigger();
    }
}
