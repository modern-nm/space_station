using Content.Server.Chat.Systems;
using Content.Shared.ADT.UniversalRecorder;
using Content.Shared.Chat;
using Linguini.Syntax.Ast;
using Robust.Shared.Random;
using Robust.Shared.Replays;
using System;

namespace Content.Server.ADT.UniversalRecorder;

public sealed partial class RecordableFlashSystem : SharedRecordableFlashSystem//EntitySystem
{
    [Dependency] private readonly IReplayRecordingManager _replay = default!;
    [Dependency] private readonly ChatSystem _chatSystem = default!;
    [Dependency] private readonly IRobustRandom _random = default!;

    public override void Initialize()
    {
        base.Initialize();
        //SubscribeLocalEvent<RecordableFlashComponent, EntitySpokeEvent>(OnEntitySpoke); хуйня. вызывается только во время речи самого RecordableFlash
    }

    private void OnEntitySpoke(EntityUid uid, RecordableFlashComponent component, EntitySpokeEvent args)
    {

        var speech = _chatSystem.GetSpeechVerb(args.Source, args.Message);
        //_replay.
        var record = new RecordedMessage
        {
            time = component.CurrentTime,
            sourceName = Name(args.Source),
            verb = Loc.GetString(_random.Pick(speech.SpeechVerbStrings)),
            message = args.Message
        };
        component.Records.Add(record);
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
