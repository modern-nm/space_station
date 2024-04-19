using System.Linq;
using Content.Shared.Access.Components;
using Content.Shared.ActionBlocker;
using Content.Shared.Actions;
using Content.Shared.Destructible;
using Content.Shared.DoAfter;
using Content.Shared.DragDrop;
using Content.Shared.FixedPoint;
using Content.Shared.Interaction;
using Content.Shared.Interaction.Components;
using Content.Shared.Interaction.Events;
using Content.Shared.Mech.Components;
using Content.Shared.Mech.Equipment.Components;
using Content.Shared.Movement.Components;
using Content.Shared.Movement.Systems;
using Content.Shared.Popups;
using Content.Shared.Weapons.Melee;
using Robust.Shared.Containers;
using Robust.Shared.Network;
using Robust.Shared.Serialization;
using Robust.Shared.Timing;
using Robust.Shared.Audio.Systems;
using Content.Shared.Access.Systems;
using Content.Shared.Damage;
using Robust.Shared.Random;
using Content.Server.Pulling;
using Content.Shared.Xenoarchaeology.XenoArtifacts;
using Content.Shared._Rat.Hitch;
using Content.Shared.Strip;
using Content.Server.Atmos.Components;
using Content.Shared.Strip.Components;

namespace Content.Server._Rat.Hitch
{
    public sealed class HitchSystem : SharedHitchSystem
    {
        [Dependency] private readonly PullingSystem _pullingSystem = default!;

        bool can = true;

        public override void Initialize()
        {
            base.Initialize();
            SubscribeLocalEvent<HitchComponent, DragDropTargetEvent>(OnDragDrop);
        }


        private void OnDragDrop(EntityUid uid, HitchComponent component, ref DragDropTargetEvent args)
        {
            _pullingSystem.TryStartPull(args.User, args.Dragged);
        }

        //private void OnCanDragDrop(EntityUid uid, MechComponent component, ref CanDropTargetEvent args)
    }
}
