using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LoadNextLevel : MonoBehaviour
{
    private bool inRange;

    public Canvas instructions;

    private void Start()
    {
        instructions.GetComponent<Canvas>().enabled = false;
    }


    // display the notification on menu enter or exit
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        ToggleInstructions();
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        ToggleInstructions();
    }

    // display the notification
    private void ToggleInstructions()
    {
        if (instructions.isActiveAndEnabled)
        {
            instructions.GetComponent<Canvas>().enabled = false;
        } else
        {
            instructions.GetComponent<Canvas>().enabled = true;
        }
    }

    void OnInteract()
    {
        if (inRange && instructions.isActiveAndEnabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
