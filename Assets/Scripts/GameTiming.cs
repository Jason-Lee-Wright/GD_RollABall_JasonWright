using System;
using UnityEngine;

public static class GameTiming
{
    public static float BPM = 57f;
    public static float BeatInterval => 60f / BPM;

    public static float SongPosition { get; private set; }
    public static float BeatProgress { get; private set; }

    private static float lastBeatTime;

    public static void UpdateTiming()
    {
        SongPosition += Time.deltaTime;
        if (SongPosition > (60f/BPM)*1000f) SongPosition = 0f;

        BeatProgress = (SongPosition % BeatInterval) / BeatInterval;

        // Detect when a new beat starts
        if (SongPosition - lastBeatTime >= BeatInterval)
        {
            lastBeatTime = SongPosition;
            TimingEvents.TriggerPulse();
        }
    }

    public static float GetClosenessToBeat()
    {
        float beatProgress = (SongPosition % BeatInterval) / BeatInterval;
        float closeness = 1f - beatProgress; // 1 on beat, 0 before next
        return Mathf.Clamp01(closeness);
    }
}

public static class TimingEvents
{
    public static event Action OnPulse;

    public static void TriggerPulse()
    {
        OnPulse?.Invoke();
    }
}