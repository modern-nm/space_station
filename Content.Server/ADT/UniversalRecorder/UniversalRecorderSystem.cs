using Content.Server.Paper;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Interaction.Events;
using Content.Shared.Verbs;
using Robust.Shared.Utility;

namespace Content.Shared.ADT.UniversalRecorder;

public sealed partial class UniversalRecorderSystem : SharedUniversalRecorderSystem
{
    public override void Initialize()
    {
        base.Initialize();
        //SubscribeLocalEvent<UniversalRecorderComponent, UseInHandEvent>(OnRecorderUsedInHand);
        //SubscribeLocalEvent<UniversalRecorderComponent, GetVerbsEvent<AlternativeVerb>>(OnRecorderVerbs);
    }

    public override void PrintRecordedMessages(EntityUid uid, UniversalRecorderComponent component, EntityUid user)
    {
        var result = Spawn("Paper", Transform(uid).Coordinates);
        var comp = Comp<PaperComponent>(result);
        //comp.Content =
        var itemSlotsComponent = Comp<ItemSlotsComponent>(component.Owner);
        itemSlotsComponent.Slots.TryFirstOrNull(out var element);
        if (element?.Value.Item != null)
        {
            if(TryComp<RecordableFlashComponent>(element?.Value.Item, out var recordableFlashComponent))
            {
                foreach (var item in recordableFlashComponent.Records)
                {
                    comp.Content += item.WrapMessage() + "\n";
                }
            }
        }
    }
    //private void OnRecorderVerbs(EntityUid uid, UniversalRecorderComponent component, GetVerbsEvent<AlternativeVerb> args)
    //{
    //    if (!args.CanAccess || !args.CanInteract || args.Hands == null)
    //        return;

    //    args.Verbs.Add(new AlternativeVerb()
    //    {
    //        Text = Loc.GetString("tool-universal_recorder-print"),
    //        //Disabled = !AnyRevolverCartridges(component),
    //        Act = () => PrintRecordedMessages(uid, component, args.User),
    //        //Priority = 1
    //    });

    //    // args.Verbs.Add(new AlternativeVerb()
    //    // {
    //    //     Text = Loc.GetString("gun-revolver-spin"),
    //    //     // Category = VerbCategory.G,
    //    //     Act = () => SpinRevolver(uid, component, args.User)
    //    // });
    //}

    //private void PrintRecordedMessages(EntityUid uid, UniversalRecorderComponent component, EntityUid user)
    //{
    //    var result = Spawn("Paper", Transform(uid).Coordinates);
    //}

    //private void OnRecorderUsedInHand(EntityUid uid, UniversalRecorderComponent component, UseInHandEvent args)
    //{
    //    if (!component.isRecording)
    //        component.isRecording = true;
    //    else
    //        component.isRecording = false;
    //}
}
