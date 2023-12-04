namespace DeathsDoor.ItemChanger;

public class BombItem : Item
{
    public static readonly BombItem Instance = new();

    public string DisplayName => HasLevel1 ? "Bomb Level 2" : "Bomb";

    public void Trigger()
    {
        if (HasLevel1)
        {
            WeaponSwitcher.instance.Upgrade("bombs");
        }
        else
        {
            WeaponSwitcher.instance.UnlockBombs();
        }
    }

    private static bool HasLevel1 => WeaponSwitcher.instance.unlocked_bombs;
}
