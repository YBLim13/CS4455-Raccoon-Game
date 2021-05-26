using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicVolumeController : MonoBehaviour
{
    private static MainMusicVolumeController _instance;
    private LevelStateManager.LevelState currentLevel;
    [SerializeField]
    private AudioSource _audioSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = LevelStateManager.Instance.GetCurr();

        switch (currentLevel) {
            case LevelStateManager.LevelState.Home_Scene:
                _audioSource.volume = 0.01f;
                break;
            case LevelStateManager.LevelState.Junkyard:
            case LevelStateManager.LevelState.City:
            case LevelStateManager.LevelState.Town_Center:
            case LevelStateManager.LevelState.City_Hall:
                _audioSource.volume = 0.02f;
                break;
            case LevelStateManager.LevelState.Home_Screen:
                Destroy(this.gameObject);
                break;
            case LevelStateManager.LevelState.Win_Screen:
                StartCoroutine(DropVolume());
                break;
        }
    }

    IEnumerator DropVolume() {
        float currVol = _audioSource.volume;
        while (_audioSource.volume > 0) {
            _audioSource.volume -= currVol/10;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
