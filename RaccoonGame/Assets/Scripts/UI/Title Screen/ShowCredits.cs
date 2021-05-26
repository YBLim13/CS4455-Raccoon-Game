using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CanvasGroup))]
public class ShowCredits : MonoBehaviour
{
    public GameObject button;
    CanvasGroup controls;

    public void ShowCreditsScreen()
    {
        controls = button.GetComponent<CanvasGroup>();

        controls.interactable = true;
        controls.blocksRaycasts = true;
        controls.alpha = 1f;
    }
}
