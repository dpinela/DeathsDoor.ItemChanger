namespace DDoor.ItemChanger;

public class ArrowUpgradeItem : Item
{
    private ArrowUpgradeItem() {}

    public static readonly ArrowUpgradeItem Instance = new();

    public string DisplayName => "Arrow Level 2";

    public void Trigger()
    {
        WeaponSwitcher.instance.Upgrade("arrows");
    }
}
