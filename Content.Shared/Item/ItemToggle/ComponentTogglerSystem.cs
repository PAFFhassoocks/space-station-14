using Content.Shared.Item.ItemToggle.Components;

namespace Content.Shared.Item.ItemToggle;

/// <summary>
/// Handles <see cref="ComponentTogglerComponent"/> component manipulation.
/// </summary>
public sealed class ComponentTogglerSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ComponentTogglerComponent, ItemToggledEvent>(OnToggled);
    }

    private void OnToggled(Entity<ComponentTogglerComponent> ent, ref ItemToggledEvent args)
    {
        if (args.Activated)
        {
            var parent = Transform(ent).ParentUid;

            if (ent.Comp.SelfComponents != null && !TerminatingOrDeleted(ent))
            {
                EntityManager.AddComponents(ent, ent.Comp.SelfComponents);
            }

            if (ent.Comp.ParentComponents != null && !TerminatingOrDeleted(parent))
            {
                ent.Comp.TargetParent = parent;
                EntityManager.AddComponents(parent, ent.Comp.ParentComponents);
            }
        }
        else
        {
            if (!TerminatingOrDeleted(ent) &&
                (ent.Comp.RemoveSelfComponents != null || ent.Comp.SelfComponents != null))
                EntityManager.RemoveComponents(ent, ent.Comp.RemoveSelfComponents ?? ent.Comp.SelfComponents!);

            var parent = ent.Comp.TargetParent;

            if (parent != null
                && !TerminatingOrDeleted(parent) &&
                (ent.Comp.RemoveParentComponents != null || ent.Comp.ParentComponents != null))
                EntityManager.RemoveComponents(parent.Value, ent.Comp.RemoveParentComponents ?? ent.Comp.ParentComponents!);
        }
    }
}
