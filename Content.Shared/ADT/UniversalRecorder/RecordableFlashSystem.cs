using Content.Shared;
using Content.Shared.Chat;

namespace Content.Shared.ADT.UniversalRecorder;

public sealed partial class UniversalRecorderSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

    }

    public bool TryRecordMessage(ChatMessage message, ref UniversalRecorderComponent component)
    {
        if (message.Channel != ChatChannel.IC)
            return false;
        component.MessagesRecorded.Add(message.WrappedMessage);
        return true;
    }
}
