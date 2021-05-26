using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    private static HealthController _instance;
    public static HealthController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("HealthController has yet to be created");
            }

            return _instance;
        }
    }

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

        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }


    public GameObject heart1, heart2, heart3;
    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    public static int health;
    public float waitTime = 2f;

    private bool loadedEnd = false;

    void Start()
    {
        
        //gameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelStateManager.Instance.GetCurr() == LevelStateManager.LevelState.Win_Screen ||
            LevelStateManager.Instance.GetCurr() == LevelStateManager.LevelState.Home_Screen) {
            Destroy(this.gameObject);
        }
        health = InventoryManager.Instance.healthCount;
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                if (!loadedEnd) {
                    loadedEnd = true;
                    Invoke("LoadGameOver", waitTime);
                }

                break;
        }

    }

    public void LoadGameOver()
    {
        if (LevelStateManager.Instance.GetCurr() != LevelStateManager.LevelState.Game_Over_Screen)
        {
            LevelStateManager.LevelState nextState = LevelStateManager.LevelState.Game_Over_Screen;
            StartCoroutine(DropVolume());
            int _sceneIndex = LevelStateManager.Instance.ChangeState(nextState);
            //SceneManager.LoadScene(_sceneIndex);
            Time.timeScale = 1f;
        }
    }

    IEnumerator DropVolume() {
        float currVol = _audio.volume;
        while (_audio.volume > 0) {
            _audio.volume -= currVol/10;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
