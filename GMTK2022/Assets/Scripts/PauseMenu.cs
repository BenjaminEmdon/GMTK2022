using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;  // enabled/disabled when pausing/unpausing

    private void OnEnable()
    {
        PauseManager.onPauseValueChanged += OnPauseValueChanged;
    }

    private void OnDisable()
    {
        PauseManager.onPauseValueChanged -= OnPauseValueChanged;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseManager.TogglePause();
        }
    }

    private void OnPauseValueChanged(bool paused)
    {
        canvas.enabled = paused;
    }
}