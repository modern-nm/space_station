using Content.Shared.Interaction.Events;
using Content.Shared.Paper;
using Content.Shared.Verbs;

namespace Content.Shared.ADT.UniversalRecorder;

public abstract class SharedUniversalRecorderSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<UniversalRecorderComponent, UseInHandEvent>(OnRecorderUsedInHand);
        SubscribeLocalEvent<UniversalRecorderComponent, GetVerbsEvent<AlternativeVerb>>(OnRecorderVerbs);
    }

    private void OnRecorderVerbs(EntityUid uid, UniversalRecorderComponent component, GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanAccess || !args.CanInteract || args.Hands == null)
            return;

        args.Verbs.Add(new AlternativeVerb()
        {
            Text = Loc.GetString("tool-universal_recorder-print"),
            //Disabled = !AnyRevolverCartridges(component),
            Act = () => PrintRecordedMessages(uid, component, args.User),
            Priority = 1
        });

        // args.Verbs.Add(new AlternativeVerb()
        // {
        //     Text = Loc.GetString("gun-revolver-spin"),
        //     // Category = VerbCategory.G,
        //     Act = () => SpinRevolver(uid, component, args.User)
        // });
    }

    public abstract void PrintRecordedMessages(EntityUid uid, UniversalRecorderComponent component, EntityUid user);
    // {
    //     var result = Spawn("Paper", Transform(uid).Coordinates);
    //     //_ = TryComp(result, out SharedPaperComponent? paperComponent);



    // }

    private void OnRecorderUsedInHand(EntityUid uid, UniversalRecorderComponent component, UseInHandEvent args)
    {
        if (!component.isRecording)
            component.isRecording = true;
        else
            component.isRecording = false;
    }
}
