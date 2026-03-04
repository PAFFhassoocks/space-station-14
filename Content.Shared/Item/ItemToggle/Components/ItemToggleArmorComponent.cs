using Content.Shared.Damage;
using Robust.Shared.GameStates;

namespace Content.Shared.Item.ItemToggle.Components;

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
