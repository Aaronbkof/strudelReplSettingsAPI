public class Settings
{
    public int Id { get; set; }

    // synthesizer controls (from the jsonHandling.js)

    // bassline controls
    public string P1State { get; set; } = "on";
    public string BasslinePattern { get; set; } = "0";

    // arpeggiator controls
    public string P2State { get; set; } = "on";
    public string ArpPattern { get; set; } = "0";

    // drum controls
    public bool DrumsEnabled { get; set; } = true;
    public string DrumPattern { get; set; } = "0";

    // default slider values with sets
    public string ReverbValue { get; set; } = "0.6";
    public string VolumeValue { get; set; } = "1.0";
    public string BpmValue { get; set; } = "140";
    public string SecValue { get; set; } = "60";
    public string CycleValue { get; set; } = "4";

    // date metadata 
    public DateTime SavedAt { get; set; } = DateTime.UtcNow;
}