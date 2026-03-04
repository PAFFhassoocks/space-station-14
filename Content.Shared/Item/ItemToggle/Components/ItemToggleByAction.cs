using Content.Shared.Actions.Components;
using Content.Shared.Inventory;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Shared.Item.ItemToggle.Components;

/// <summary>
/// Gives a action to the player that has this a item equipped, this action toggles <see cref="ItemToggleComponent"/>
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState, AutoGenerateComponentPause]
public sealed partial class ItemToggleByActionComponent : Component
{
    /// <summary>
    /// The action to add when equipped, even if not worn.
    /// This must raise <see cref="ToggleActionEvent"/> to then get handled.
    /// </summary>
    [DataField(required: true)]
    public EntProtoId<InstantActionComponent> Action;

    [DataField, AutoNetworkedField]
    public EntityUid? ActionEntity;

    /// <summary>
    /// The inventory slot flags required for this component to function.
    /// </summary>
    [DataField, AutoNetworkedField]
    public SlotFlags RequiredFlags = SlotFlags.OUTERCLOTHING;
}
