namespace DDoor.ItemChanger;

public class FireItem : Item
{
    public static readonly FireItem Instance = new();

    public string DisplayName => HasLevel1 ? "Fire Level 2" : "Fire";

    public void Trigger()
    {
        if (HasLevel1)
        {
            WeaponSwitcher.instance.Upgrade("fire");
        }
        else
        {
            WeaponSwitcher.instance.UnlockFire();
        }
    }

    private static bool HasLevel1 => WeaponSwitcher.instance.unlocked_fire;
}
