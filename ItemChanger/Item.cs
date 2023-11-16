namespace DDoorItemChanger;

public interface Item
{
    public bool Obtained { get; }

    public string DisplayName { get; }

    public void Trigger();
}