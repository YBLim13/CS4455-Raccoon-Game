using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition_Collider_Town : MonoBehaviour
{
    public LevelStateManager.LevelState nextState = LevelStateManager.LevelState.Home_Screen;
    private int _sceneIndex = 0;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" && PickupController.myInt >= 7) {
            _sceneIndex = LevelStateManager.Instance.ChangeState(nextState);

            //SceneManager.LoadScene(_sceneIndex);
        }
    }
}
