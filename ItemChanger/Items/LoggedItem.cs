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

    public void Trigger()
    {
        SaveData.Open().AddToTrackerLog(Item.DisplayName, Where);
        Item.Trigger();
    }
}
