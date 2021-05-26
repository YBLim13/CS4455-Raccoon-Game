using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            Time.timeScale = 0f;
        }

    }

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
}
