// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class HealthResume : MonoBehaviour
// {
//     public GameObject menu, overlay;
//     CanvasGroup canvasGroup;

//     public void StartGame()
//     {
//         HealthController.Instsance.health = 3;

//         canvasGroup = menu.GetComponent<CanvasGroup>();
//         canvasGroup.interactable = false;
//         canvasGroup.blocksRaycasts = false;
//         canvasGroup.alpha = 0f;

//         canvasGroup = overlay.GetComponent<CanvasGroup>();
//         canvasGroup.alpha = 1f;
//         Time.timeScale = 1f;

//     }
// }
