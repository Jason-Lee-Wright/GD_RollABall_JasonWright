using System;
using UnityEngine;

public class GameTiming : MonoBehaviour
{
    public float BPMGlobal = 114f;


}

static class TimingEvents
{
    new static Action PulseEvent;
}