using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CanvasGroup))]
public class HideControls : MonoBehaviour
{
    public GameObject button;
    CanvasGroup controls;

    public void HideControlScreen()
    {
        controls = button.GetComponent<CanvasGroup>();

        controls.interactable = false;
        controls.blocksRaycasts = false;
        controls.alpha = 0f;
    }
}
