namespace DDoorItemChanger;

public class HookshotItem : Item
{
    public static readonly HookshotItem Instance = new();

    public string DisplayName => HasLevel1 ? "Hookshot Level 2" : "Hookshot";

    public void Trigger()
    {
        if (HasLevel1)
        {
            WeaponSwitcher.instance.Upgrade("hookshot");
        }
        else
        {
            WeaponSwitcher.instance.UnlockHooskhot();
        }
    }

    private static bool HasLevel1 => WeaponSwitcher.instance.unlocked_hookshot;
}
