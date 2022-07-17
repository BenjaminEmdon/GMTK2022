using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ConfirmAction : MonoBehaviour
{
    [Header("Declarations")]
    [SerializeField]
    private Button cancelButton;
    [SerializeField]
    private GameObject[] uiObjs;

    [Header("Action Info")]
    public Action[] actions;

    [System.Serializable]
    public struct Action
    {
        public Button button;
        public UnityEvent response;
    }

    private bool triggeredPrompt = false;

    private void Awake()
    {
        SetUIActive(triggeredPrompt);
    }

    public void Prompt()
    {
        triggeredPrompt = true;

        // Show UI
        SetUIActive(true);

        // Listen for buttons' onClick
        cancelButton.onClick.AddListener(Cancel);
        for (int i = 0; i < actions.Length; i++)
        {
            if (actions[i].button != null)
            {
                var _i = i;
                actions[i].button.onClick.AddListener(() => { OnClick(_i); });
            }
        }
    }

    public void Cancel()
    {
        if (triggeredPrompt)
        {
            triggeredPrompt = false;

            // Stop listening for buttons' onClick
            cancelButton.onClick.RemoveListener(Cancel);
            for (int i = 0; i < actions.Length; i++)
            {
                if (actions[i].button != null)
                {
                    actions[i].button.onClick.RemoveListener(() => { OnClick(i); });
                }
            }
        }

        // Hide UI
        SetUIActive(false);
    }

    private void SetUIActive(bool value)
    {
        for (int i = 0; i < uiObjs.Length; i++)
        {
            uiObjs[i].SetActive(value);
        }
    }

    public void OnClick(int actionIndex)
    {
        if (actions[actionIndex].response != null)
        {
            actions[actionIndex].response.Invoke();
        }
    }
}