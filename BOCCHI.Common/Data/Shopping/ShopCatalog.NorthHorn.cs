using BOCCHI.Common.Data.SupportJobs;
using BOCCHI.Common.Data.Zones;

namespace BOCCHI.Common.Data.Shopping;

public static partial class ShopCatalog
{
    // SelectIconString menu indices for Expedition Antiquarian (North Horn).
    private const int NhMenuSilverGear = 0;
    private const int NhMenuSilverOther = 1;
    private const int NhMenuGold = 2;
    private const int NhMenuAmulet = 3;

    private static IEnumerable<ShopCatalogEntry> BuildNorthHorn()
    {
        ZoneId z = ZoneId.NorthHorn;
        uint silver = SilverObolItemId;
        uint gold = GoldObolItemId;
        uint amulet = ArcaneAmuletItemId;

        // Phantom Vision — one role block each (same order as South Horn / in-game).
        foreach (ShopCatalogEntry e in ArmorSet(
                     z, silver, NhMenuSilverGear, "Silver · Fending",
                     52000,
                     "Phantom Vision Mask of Fending",
                     "Phantom Vision Corselet of Fending",
                     "Phantom Vision Vambraces of Fending",
                     "Phantom Vision Bottoms of Fending",
                     "Phantom Vision Sollerets of Fending"))
        {
            yield return e;
        }

        foreach (ShopCatalogEntry e in ArmorSet(
                     z, silver, NhMenuSilverGear, "Silver · Maiming",
                     52005,
                     "Phantom Vision Mask of Maiming",
                     "Phantom Vision Corselet of Maiming",
                     "Phantom Vision Vambraces of Maiming",
                     "Phantom Vision Bottoms of Maiming",
                     "Phantom Vision Sollerets of Maiming"))
        {
            yield return e;
        }

        foreach (ShopCatalogEntry e in ArmorSet(
                     z, silver, NhMenuSilverGear, "Silver · Striking",
                     52010,
                     "Phantom Vision Turban of Striking",
                     "Phantom Vision Robe of Striking",
                     "Phantom Vision Wristwraps of Striking",
                     "Phantom Vision Sarouel of Striking",
                     "Phantom Vision Boots of Striking"))
        {
            yield return e;
        }

        foreach (ShopCatalogEntry e in ArmorSet(
                     z, silver, NhMenuSilverGear, "Silver · Aiming",
                     52020,
                     "Phantom Vision Turban of Aiming",
                     "Phantom Vision Robe of Aiming",
                     "Phantom Vision Wristwraps of Aiming",
                     "Phantom Vision Sarouel of Aiming",
                     "Phantom Vision Boots of Aiming"))
        {
            yield return e;
        }

        foreach (ShopCatalogEntry e in ArmorSet(
                     z, silver, NhMenuSilverGear, "Silver · Scouting",
                     52015,
                     "Phantom Vision Turban of Scouting",
                     "Phantom Vision Robe of Scouting",
                     "Phantom Vision Wristwraps of Scouting",
                     "Phantom Vision Sarouel of Scouting",
                     "Phantom Vision Boots of Scouting"))
        {
            yield return e;
        }

        foreach (ShopCatalogEntry e in ArmorSet(
                     z, silver, NhMenuSilverGear, "Silver · Healing",
                     52030,
                     "Phantom Vision Nightcap of Healing",
                     "Phantom Vision Acton of Healing",
                     "Phantom Vision Wristwraps of Healing",
                     "Phantom Vision Sarouel of Healing",
                     "Phantom Vision Crakows of Healing"))
        {
            yield return e;
        }

        foreach (ShopCatalogEntry e in ArmorSet(
                     z, silver, NhMenuSilverGear, "Silver · Casting",
                     52025,
                     "Phantom Vision Nightcap of Casting",
                     "Phantom Vision Acton of Casting",
                     "Phantom Vision Wristwraps of Casting",
                     "Phantom Vision Sarouel of Casting",
                     "Phantom Vision Crakows of Casting"))
        {
            yield return e;
        }

        yield return E(51980, "Ninja's Soul Shard", 1000, silver, NhMenuSilverOther, z, ShopOwnershipKind.PhantomJob, "Silver · Other", SupportJobId.PhantomNinja);
        yield return E(51981, "Black Mage's Soul Shard", 1000, silver, NhMenuSilverOther, z, ShopOwnershipKind.PhantomJob, "Silver · Other", SupportJobId.PhantomBlackMage);
        yield return E(51982, "White Mage's Soul Shard", 1000, silver, NhMenuSilverOther, z, ShopOwnershipKind.PhantomJob, "Silver · Other", SupportJobId.PhantomWhiteMage);
        yield return E(51983, "Red Mage's Soul Shard", 1000, silver, NhMenuSilverOther, z, ShopOwnershipKind.PhantomJob, "Silver · Other", SupportJobId.PhantomRedMage);
        yield return E(51966, "North Horn Riding Map", 3000, silver, NhMenuSilverOther, z, ShopOwnershipKind.KeyItem, "Silver · Other");
        yield return E(51985, "Final Final Fixative", 1200, silver, NhMenuSilverOther, z, ShopOwnershipKind.Repeatable, "Silver · Other");
        yield return E(51986, "Nymian Uolosapa", 500, silver, NhMenuSilverOther, z, ShopOwnershipKind.Minion, "Silver · Other");
        yield return E(45970, "Occult Coffer", 40, silver, NhMenuSilverOther, z, ShopOwnershipKind.Repeatable, "Silver · Other");
        yield return E(45969, "Occult Potion", 40, silver, NhMenuSilverOther, z, ShopOwnershipKind.Repeatable, "Silver · Other");

        foreach (ShopCatalogEntry m in MateriaPack(z, silver, NhMenuSilverOther, "Silver · Other", xi: 100, xii: 200))
        {
            yield return m;
        }

        yield return E(51990, "Dragoon's Soul Shard", 1600, gold, NhMenuGold, z, ShopOwnershipKind.PhantomJob, "Gold", SupportJobId.PhantomDragoon);
        yield return E(51991, "Summoner's Soul Shard", 1600, gold, NhMenuGold, z, ShopOwnershipKind.PhantomJob, "Gold", SupportJobId.PhantomSummoner);
        yield return E(51985, "Final Final Fixative", 1920, gold, NhMenuGold, z, ShopOwnershipKind.Repeatable, "Gold");
        yield return E(45970, "Occult Coffer", 50, gold, NhMenuGold, z, ShopOwnershipKind.Repeatable, "Gold");
        yield return E(45969, "Occult Potion", 50, gold, NhMenuGold, z, ShopOwnershipKind.Repeatable, "Gold");

        foreach (ShopCatalogEntry m in MateriaPack(z, gold, NhMenuGold, "Gold", xi: 160, xii: 320))
        {
            yield return m;
        }

        // Arcane Amulet exchange (unlock-gated).
        yield return E(51985, "Final Final Fixative", 30, amulet, NhMenuAmulet, z, ShopOwnershipKind.Repeatable, "Arcane Amulet");
    }
}
