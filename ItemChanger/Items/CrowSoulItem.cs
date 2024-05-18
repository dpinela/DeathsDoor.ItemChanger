namespace DDoor.ItemChanger;

internal class CrowSoulItem : Item
{
    public string UniqueId { get; set; } = "";

    public string DisplayName { get; set; } = "";

    public string Icon => "Soul";

    public void Trigger()
    {
        var save = GameSave.GetSaveData();
        save.SetKeyState(UniqueId, true);
        save.AddToCountKey("crow_soul_count");
    }
}