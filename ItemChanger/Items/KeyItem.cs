namespace DDoorItemChanger;

internal class KeyItem : Item
{
    public string DisplayName { get; set; } = "";

    public string UniqueId { get; set; } = "";

    public void Trigger()
    {
        GameSave.GetSaveData().SetKeyState(UniqueId, true);
    }
}