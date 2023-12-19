using Content.Shared.Chat;

namespace Content.Shared.ADT.UniversalRecorder;

[RegisterComponent]
public sealed partial class UniversalRecorderComponent : Component
{
    [DataField("capacity")]
    public TimeSpan Capacity = TimeSpan.FromMinutes(10);

    public List<string> MessagesRecorded = new List<string>();
}
