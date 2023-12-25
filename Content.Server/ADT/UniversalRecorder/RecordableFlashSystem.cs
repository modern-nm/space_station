using Content.Shared.ADT.UniversalRecorder;
using Content.Shared.Chat;

namespace Content.Server.ADT.UniversalRecorder;

public sealed partial class RecordableFlashSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

    }

    public bool TryRecordMessage(ChatMessage message, ref RecordableFlashComponent component)
    {
        if (message.Channel != ChatChannel.IC)
            return false;
        component.MessagesRecorded.Add(message.WrappedMessage);
        return true;
    }
}
