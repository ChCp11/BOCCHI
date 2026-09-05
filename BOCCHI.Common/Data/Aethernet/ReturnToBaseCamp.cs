using BOCCHI.Common.Data.Zones;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.UI;
using Ocelot.Actions;
using Ocelot.Chain;
using Ocelot.Chain.Extensions;
using Ocelot.Ipc.VNavmesh;
using Ocelot.Services.Pathfinding;

namespace BOCCHI.Common.Data.Aethernet;

/// <summary>
///     Cast Return / Demi-Return and wait until base camp (auto-accepts the Yesno).
/// </summary>
public static class ReturnToBaseCamp
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(120);

    public static IChain Append(
        IChain chain,
        IZoneProvider zones,
        ICondition conditions,
        IGameGui gui,
        IPathfinder pathfinder,
        IVNavmeshIpc vnav,
        bool dismountBeforeReturn = true)
    {
        string chainName = chain.Name;

        return chain
            .Then(_ =>
                {
                    pathfinder.Stop();
                    vnav.Stop();

                    if (zones.GetZone().IsInBasecamp())
                    {
                        return StepResult.Success();
                    }

                    if (conditions[ConditionFlag.Unconscious])
                    {
                        return StepResult.Failure("Cannot Return while unconscious.");
                    }

                    if (conditions[ConditionFlag.InCombat])
                    {
                        return StepResult.Failure("Cannot Return while in combat.");
                    }

                    // Return is often blocked while mounted.
                    if (dismountBeforeReturn && DismountAssist.TryDismount(conditions))
                    {
                        return StepResult.Success();
                    }

                    if (Actions.Return.CanCast())
                    {
                        Actions.Return.Cast();
                    }

                    return StepResult.Success();
                }, $"{chainName}::CastReturn")
            .WaitUntil(
                _ =>
                {
                    if (zones.GetZone().IsInBasecamp())
                    {
                        return ValueTask.FromResult(true);
                    }

                    if (conditions[ConditionFlag.Unconscious] || conditions[ConditionFlag.InCombat])
                    {
                        return ValueTask.FromResult(false);
                    }

                    TryConfirmReturnDialog(gui, conditions);

                    if (dismountBeforeReturn && DismountAssist.TryDismount(conditions))
                    {
                        return ValueTask.FromResult(false);
                    }

                    if (Actions.Return.CanCast())
                    {
                        Actions.Return.Cast();
                    }

                    return ValueTask.FromResult(false);
                },
                Timeout,
                TimeSpan.FromMilliseconds(250),
                $"{chainName}::WaitForBasecamp");
    }

    private static unsafe void TryConfirmReturnDialog(IGameGui gui, ICondition conditions)
    {
        if (conditions[ConditionFlag.Unconscious])
        {
            return;
        }

        AddonSelectYesno* yesno = gui.GetAddonByName<AddonSelectYesno>("SelectYesno");
        if (yesno == null)
        {
            return;
        }

        ReturnYesNo.TryAccept(&yesno->AtkUnitBase);
    }
}
