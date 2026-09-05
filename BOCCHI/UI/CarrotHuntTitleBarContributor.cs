using System.Numerics;
using BOCCHI.Treasure.Services;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Windowing;
using Ocelot.Windows;
using Ocelot.Lifecycle;

namespace BOCCHI.UI;

/// <summary>Compact Carrot Hunt toggle beside the existing title-bar actions.</summary>
public sealed class CarrotHuntTitleBarContributor(ICarrotHunter carrotHunter)
    : IMainWindowTitleBarContributor, IOnUpdate
{
    private static readonly Vector4 ActiveOrange = new(1f, 0.45f, 0.08f, 1f);

    private TitleBarButton? button;

    public void Contribute(ICollection<TitleBarButton> buttons)
    {
        button = new TitleBarButton
        {
            Icon = FontAwesomeIcon.Carrot,
            IconColor = carrotHunter.Running ? ActiveOrange : null,
            IconOffset = new Vector2(1, 1),
            Click = mouseButton =>
            {
                if (mouseButton == ImGuiMouseButton.Left)
                {
                    carrotHunter.Toggle();
                    UpdateColor();
                }
            },
            ShowTooltip = () => ImGui.SetTooltip(
                carrotHunter.Running
                    ? "キャロットハントを停止"
                    : "キャロットハントを開始"),
        };
        buttons.Add(button);
    }

    public void Update() => UpdateColor();

    private void UpdateColor()
    {
        if (button != null)
        {
            button.IconColor = carrotHunter.Running ? ActiveOrange : null;
        }
    }
}
