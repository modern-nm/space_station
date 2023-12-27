using Content.Shared.Chat;
using Robust.Shared.Toolshed.Commands.GameTiming;

namespace Content.Shared.ADT.UniversalRecorder;

[RegisterComponent]
public sealed partial class RecordableFlashComponent : Component
{
    [DataField("capacity")]
    public TimeSpan Capacity = TimeSpan.FromMinutes(10);

    //public List<string> MessagesRecorded = new List<string>();

    public List<RecordedMessage> Records = new List<RecordedMessage>();

    public int CurrentTime { get; set; }
}

public struct RecordedMessage
{
    public int time;
    public string? sourceName;
    public string? verb;
    public string? message;
    // TTS sound
    public string? action; // "started/finished recording" field

    public string WrapMessage(RecordedMessage message)
    {
        if (message.action != null)
        {
            return message.time.ToString() + " " + message.action;
        }
        if (message.message != null)
        {
            return message.time.ToString() + " " + message.sourceName + " " + message.verb + " " + message.message;
        }
        return "error";
    }
}
