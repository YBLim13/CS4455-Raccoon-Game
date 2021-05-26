using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null) {
                Debug.LogError("UI Manager has not been created");
            }

            return _instance;
        }
    }

    public TextMeshProUGUI inventoryList;

    private LevelStateManager.LevelState _currentState;
    private bool _isHomeScreen;

    void Awake()
    {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }

    private void Start() {
        _currentState = LevelStateManager.Instance.GetCurr();
        _isHomeScreen = _currentState == LevelStateManager.LevelState.Home_Screen;
    }
}
