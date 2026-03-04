using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Shared.Item.ItemToggle.Components;

/// <summary>
/// Entities with this component after being toggled will automatically untoggle after a delay
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState, AutoGenerateComponentPause]
public sealed partial class TemporaryItemToggleComponent : Component
{
    /// <summary>
    /// How long it takes for the second stage to be triggered.
    /// </summary>
    [DataField, AutoNetworkedField]
    public TimeSpan ToggleDelay = TimeSpan.FromSeconds(10);

    /// <summary>
    /// The time at which the second stage will trigger.
    /// </summary>
    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer))]
    [AutoNetworkedField, AutoPausedField]
    public TimeSpan? NextToggleTime;
}
