using Lofelt.NiceVibrations;

public static class Vibration
{
    public static void VibrationFunc()
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
    }
}
