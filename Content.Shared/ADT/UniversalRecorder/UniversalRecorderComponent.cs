namespace Content.Shared.ADT.UniversalRecorder;

[RegisterComponent]
[Access(typeof(SharedUniversalRecorderSystem))]
public sealed partial class UniversalRecorderComponent : Component
{
    [DataField("isRecording")]
    public bool isRecording { get; set; }


}
