namespace DDoor.ItemChanger;

public interface Item
{
    public string DisplayName { get; }

    public string Icon { get; }

    public void Trigger();
}