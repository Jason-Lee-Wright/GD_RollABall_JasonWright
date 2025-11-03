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

        if (BeatProgress <= 0.01f)
        {
            //Things can happen IE enemy movement.
        }

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
        float closeness = beatProgress;
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