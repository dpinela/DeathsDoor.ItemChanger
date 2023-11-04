namespace DDoorItemChanger;

public class HookshotItem : Item
{
    public static readonly HookshotItem Instance = new();

    public string DisplayName => "Hookshot";

    public string UniqueName => "Hookshot";

    public void Trigger()
    {
        ItemChangerPlugin.Log!.LogInfo("Giving hookshot");
        WeaponSwitcher.instance.UnlockHooskhot();
    }

    public bool Obtained => GameSave.GetSaveData().IsKeyUnlocked("unlocked_hookshot");
}
