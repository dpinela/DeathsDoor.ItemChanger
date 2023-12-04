namespace DeathsDoor.ItemChanger;

public interface Item
{
    public string DisplayName { get; }

    public void Trigger();
}