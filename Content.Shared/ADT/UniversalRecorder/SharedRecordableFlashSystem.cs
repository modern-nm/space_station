
using Content.Shared.ADT.UniversalRecorder;
using Content.Shared.Chat;
using Content.Shared.Interaction.Events;
using Linguini.Syntax.Ast;
using Robust.Shared.Random;
using Robust.Shared.Replays;
using System;

namespace Content.Shared.ADT.UniversalRecorder;

public abstract class SharedRecordableFlashSystem : EntitySystem
{

    public override void Initialize()
    {
        base.Initialize();
        //SubscribeLocalEvent<RecordableFlashComponent, UseInHandEvent>(OnFlashUsedInHand);
    }

}
