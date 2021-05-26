using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CanvasGroup))]
public class ItemMenuToggle : MonoBehaviour
{
    public GameObject itemList;

    private CanvasGroup canvasGroup;
    private bool shown = false;
    private ItemList items;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (!shown)
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
                Time.timeScale = 0f;
                items.Init();
                shown = true;
            } else
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;
                Time.timeScale = 1f;
                items.Close();
                shown = false;
            }
        }

    }

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        items = itemList.GetComponent<ItemList>();
    }
}
