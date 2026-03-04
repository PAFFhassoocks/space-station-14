using Robust.Shared.GameStates;
using Robust.Shared.Utility;

namespace Content.Shared.Utility;

/// <summary>
/// Adds a sprite on top of entity
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class SpriteOverlayComponent : Component
{
    /// <summary>
    /// Sprite to add.
    /// </summary>
    [DataField]
    public SpriteSpecifier.Rsi? Sprite = new(new ResPath("/Textures/Objects/Weapons/Effects"), "shield2");
}
