using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public void HomeScreen()
    {
        InventoryManager.Instance.NewGame();
        CutsceneManager.Instance.NewGame();
        LevelStateManager.Instance.ChangeState(LevelStateManager.LevelState.Home_Screen);
        Time.timeScale = 1f;
    }
}
