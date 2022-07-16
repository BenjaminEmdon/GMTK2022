using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PauseManager
{
    public static bool canPause = true;
    public static bool paused = false;

    // Events
    public delegate void OnPause();
    public static event OnPause onPause;
    public delegate void OnUnpause();
    public static event OnUnpause onUnpause;
    public delegate void OnPauseValueChanged(bool paused);
    public static event OnPauseValueChanged onPauseValueChanged;

    public static void TogglePause()
    {
        SetPaused(!paused);
    }

    public static void Pause()
    {
        SetPaused(true);
    }

    public static void Unpause()
    {
        SetPaused(false);
    }

    public static void SetPaused(bool value)
    {
        paused = value;

        onPauseValueChanged?.Invoke(value);

        if (value)
        {
            onPause?.Invoke();
        }
        else
        {
            onUnpause?.Invoke();
        }
    }
}
