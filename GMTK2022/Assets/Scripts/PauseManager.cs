using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PauseManager
{
    public static bool canPause = true;
    public static bool paused = false;
    public static bool hasPausedOnce = false;

    // Events
    public delegate void OnPause();
    public static event OnPause onPause;
    public delegate void OnUnpause();
    public static event OnUnpause onUnpause;
    public delegate void OnPauseValueChanged(bool paused);
    public static event OnPauseValueChanged onPauseValueChanged;

    public static float timeScaleBeforePause = 1.0f;

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
            if (!hasPausedOnce)
                hasPausedOnce = true;

            timeScaleBeforePause = Time.timeScale;
            Time.timeScale = 0.0f;
            onPause?.Invoke();
        }
        else
        {
            if (hasPausedOnce)
                Time.timeScale = timeScaleBeforePause;

            onUnpause?.Invoke();
        }
    }
}
