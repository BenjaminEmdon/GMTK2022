using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;  // enabled/disabled when pausing/unpausing

    [SerializeField]
    private Button resumeButton;

    private void Awake()
    {
        if (canvas == null)
            canvas = GetComponent<Canvas>();

        if (canvas == null)
            Debug.LogError("Null Reference Exception: Cannot find PauseMenu Canvas. You probably need to assign it, ya dingus.");
    }

    private void OnEnable()
    {
        PauseManager.onPauseValueChanged += OnPauseValueChanged;

        if (resumeButton != null)
            resumeButton.onClick.AddListener(PauseManager.Unpause);
    }

    private void OnDisable()
    {
        PauseManager.onPauseValueChanged -= OnPauseValueChanged;

        if (resumeButton != null)
            resumeButton.onClick.RemoveListener(PauseManager.Unpause);
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