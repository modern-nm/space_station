using Content.Server.Chat.Systems;
using Content.Shared.ADT.UniversalRecorder;
using Content.Shared.Chat;
using Linguini.Syntax.Ast;
using Robust.Shared.Random;
using Robust.Shared.Replays;
using System;

namespace Content.Server.ADT.UniversalRecorder;

public sealed partial class RecordableFlashSystem : EntitySystem
{
    [Dependency] private readonly IReplayRecordingManager _replay = default!;
    [Dependency] private readonly ChatSystem _chatSystem = default!;
    [Dependency] private readonly IRobustRandom _random = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<RecordableFlashComponent, EntitySpokeEvent>(OnEntitySpoke);
    }

    private void OnEntitySpoke(EntityUid uid, RecordableFlashComponent component, EntitySpokeEvent args)
    {
        var Record = new RecordedMessage();
        Record.time = component.CurrentTime;
        Record.sourceName = Name(args.Source);
        var speech = _chatSystem.GetSpeechVerb(args.Source, args.Message);
        //_replay.
        Record.verb = Loc.GetString(_random.Pick(speech.SpeechVerbStrings));
        Record.message = args.Message;
        component.Records.Add(Record);
        //component.Dirty();
    }

    public bool TryRecordMessage(ChatMessage message, ref RecordableFlashComponent component)
    {
        if (message.Channel != ChatChannel.IC)
            return false;
        //component.Records.Add()
        return true;
    }
}
