using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public LevelStateManager.LevelState nextState = LevelStateManager.LevelState.Home_Screen;
    private int _sceneIndex = 0;
    public int totalFurnitureNeeded = 3;

    private void OnCollisionEnter(Collision other) {
        int numItems = InventoryManager.Instance.inventory.Count;
        if (other.gameObject.tag == "Player" && numItems >= totalFurnitureNeeded) {
            FadeManager.Instance.setFadeLock(true);
            _sceneIndex = LevelStateManager.Instance.ChangeState(nextState);

            //SceneManager.LoadScene(_sceneIndex);
        }
    }

    
}
