using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter: MonoBehaviour
{
    private int _sceneIndex;

    [SerializeField]
    private AudioSource _audio;

    public void StartGame()
    {
        InventoryManager.Instance.NewGame();
        CutsceneManager.Instance.NewGame();
        StartCoroutine(DropVolume());
        _sceneIndex = LevelStateManager.Instance.ChangeState(LevelStateManager.LevelState.Home_Scene);
        //SceneManager.LoadScene(_sceneIndex);
        Time.timeScale = 1f;
    }

    IEnumerator DropVolume() {
        float currVol = _audio.volume;
        while (_audio.volume > 0) {
            _audio.volume -= currVol/10;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
