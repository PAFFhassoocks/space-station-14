using Content.Shared.Utility;
using Robust.Client.GameObjects;
using Robust.Shared.Timing;

namespace Content.Client.Utility;

public sealed class SpriteOverlaySystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = null!;
    [Dependency] private readonly SpriteSystem _sprite = null!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<SpriteOverlayComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<SpriteOverlayComponent, ComponentShutdown>(OnShutdown);
    }

    private void OnStartup(Entity<SpriteOverlayComponent> ent, ref ComponentStartup args)
    {
        if (!_timing.ApplyingState
            || ent.Comp.Sprite == null
            || !TryComp<SpriteComponent>(ent, out var sprite))
            return;

        var layer = _sprite.LayerMapReserve((ent, sprite), OverlaySpriteKey.Key);
        _sprite.LayerSetRsi((ent, sprite), layer, ent.Comp.Sprite.RsiPath, ent.Comp.Sprite.RsiState);
    }

    private void OnShutdown(Entity<SpriteOverlayComponent> ent, ref ComponentShutdown args)
    {
        if (!_timing.ApplyingState
            || !TryComp<SpriteComponent>(ent, out var sprite)
            || !_sprite.LayerMapTryGet((ent, sprite), OverlaySpriteKey.Key, out var index, false))
            return;

        _sprite.RemoveLayer((ent, sprite), index);
    }

    private enum OverlaySpriteKey : byte
    {
        Key,
    }
}
