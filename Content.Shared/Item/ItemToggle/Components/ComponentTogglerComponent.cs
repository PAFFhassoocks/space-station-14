using Content.Shared.Item.ItemToggle;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared.Item.ItemToggle.Components;

/// <summary>
/// Adds or removes components when toggled.
/// Requires <see cref="ItemToggleComponent"/>.
/// </summary>
[RegisterComponent, NetworkedComponent, Access(typeof(ComponentTogglerSystem))]
public sealed partial class ComponentTogglerComponent : Component
{
    /// <summary>
    /// The components to add to self when activated.
    /// </summary>
    [DataField]
    public ComponentRegistry? SelfComponents = new();

    /// <summary>
    /// The components to add to the entity's parent when activated.
    /// </summary>
    [DataField]
    public ComponentRegistry? ParentComponents = new();

    /// <summary>
    /// The components to remove from self when deactivated.
    /// If this is null <see cref="SelfComponents"/> is reused.
    /// </summary>
    [DataField]
    public ComponentRegistry? RemoveSelfComponents;

    /// <summary>
    /// The components to remove from the entity's parent when deactivated.
    /// If this is null <see cref="ParentComponents"/> is reused.
    /// </summary>
    [DataField]
    public ComponentRegistry? RemoveParentComponents;

    // <summary>
    // It holds the entity's parent that the component gave the component to, so it can remove from it even if it changes parent.
    // </summary>
    [DataField]
    public EntityUid? TargetParent;
}
