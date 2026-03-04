using Content.Shared.Damage;
using Robust.Shared.GameStates;

namespace Content.Shared.Item.ItemToggle.Components;

/// <summary>
/// Handles the changes to the armor component when the item is toggled.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class ItemToggleArmorComponent : Component
{
    /// <summary>
    /// The damage reduction when activated
    /// </summary>
    [DataField]
    public DamageModifierSet? ActivatedModifiers;

    /// <summary>
    /// The damage reduction when deactivated
    /// </summary>
    [DataField]
    public DamageModifierSet? DeactivatedModifiers;
}
