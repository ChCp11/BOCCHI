using BOCCHI.Common.Data.Zones;

namespace BOCCHI.Treasure.Hunt;

/// <summary>
///     User-authored North Horn carrot regions and fixed traversal order.
/// </summary>
internal enum NorthHornCarrotRegion
{
    Northeast = 0,
    Northwest = 1,
    Middle = 2,
    South = 3,
    Southwest = 4,
}

internal static class NorthHornCarrotRegions
{
    /// <summary>
    ///     Visit order. This is the single source of truth — <see cref="TourIndex"/> exists so
    ///     nothing compares raw enum values and quietly disagrees when this array is reordered.
    /// </summary>
    public static readonly NorthHornCarrotRegion[] TourOrder =
    [
        NorthHornCarrotRegion.Middle,
        NorthHornCarrotRegion.Northeast,
        NorthHornCarrotRegion.Northwest,
        NorthHornCarrotRegion.South,
        NorthHornCarrotRegion.Southwest,
    ];

    private static readonly IReadOnlyDictionary<NorthHornCarrotRegion, int[]> PadOrder =
        new Dictionary<NorthHornCarrotRegion, int[]>
        {
            [NorthHornCarrotRegion.Northeast] = [4, 8, 17, 24, 22, 5, 21],
            [NorthHornCarrotRegion.Northwest] = [15, 19, 2, 14, 16, 13, 7],
            [NorthHornCarrotRegion.Middle] = [9, 23, 1],
            [NorthHornCarrotRegion.South] = [12, 18],
            [NorthHornCarrotRegion.Southwest] = [20, 3, 25, 11, 6, 10],
        };

    public static bool AppliesTo(ZoneId zone) => zone == ZoneId.NorthHorn;

    /// <summary>Position in <see cref="TourOrder"/>; unlisted regions sort last.</summary>
    public static int TourIndex(NorthHornCarrotRegion region)
    {
        int index = Array.IndexOf(TourOrder, region);
        return index < 0 ? int.MaxValue : index;
    }

    public static int PadIndex(NorthHornCarrotRegion region, int padId)
    {
        if (!PadOrder.TryGetValue(region, out int[]? order))
        {
            return int.MaxValue;
        }

        int index = Array.IndexOf(order, padId);
        return index < 0 ? int.MaxValue : index;
    }

    public static NorthHornCarrotRegion Classify(int padId)
    {
        foreach ((NorthHornCarrotRegion region, int[] pads) in PadOrder)
        {
            if (Array.IndexOf(pads, padId) >= 0)
            {
                return region;
            }
        }

        return NorthHornCarrotRegion.Middle;
    }
}

