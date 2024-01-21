namespace DDoor.ItemChanger;

internal class KeyItem : Item
{
    public string DisplayName { get; set; } = "";

    public string Icon { get; set; } = "";

    public CollectableKey.KeyType Type { get; set; } = CollectableKey.KeyType.None;

    public void Trigger()
    {
        CollectableKey.GainKey(Type);
    }
}
