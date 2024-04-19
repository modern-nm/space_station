using Content.Shared.DragDrop;

namespace Content.Shared._Rat.Hitch
{
    public abstract partial class SharedHitchSystem : EntitySystem
    {
        public override void Initialize()
        {
            base.Initialize();
            SubscribeLocalEvent<HitchComponent, CanDropDraggedEvent>(OnCanDrop);
            SubscribeLocalEvent<HitchComponent, CanDropTargetEvent>(OnCanDropOn);

        }

        private void OnCanDrop(EntityUid uid, HitchComponent component, ref CanDropDraggedEvent args)
        {
            Log.Warning("OnCanDrop");
        }

        private void OnCanDropOn(EntityUid uid, HitchComponent component, ref CanDropTargetEvent args)
        {
            Log.Warning("OnCanDropOn");
            args.CanDrop |= true;
        }
    }


}
