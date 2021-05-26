using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateManager : MonoBehaviour
{
    private static LevelStateManager _instance;
    public static LevelStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("LevelStateManager has not been created.");
            }

            return _instance;
        }
    }

    public enum LevelState
    {
        Home_Screen = 0,
        Home_Scene = 1,
        Junkyard = 2,
        City = 3,
        Town_Center = 4,
        City_Hall = 5,
        Game_Over_Screen = 6,
        Win_Screen = 7
    }

    [SerializeField]
    private LevelState _curr = LevelState.Home_Screen;
    [SerializeField]
    private LevelState _prev = LevelState.Home_Screen;

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

    public int ChangeState(LevelState newState)
    {
        _prev = _curr;
        _curr = newState;
        int nextScene = (int) newState;

        FadeManager.Instance.TriggerFadeOut(nextScene);

        return nextScene;
    }

    public LevelState GetCurr()
    {
        return _curr;
    }

    public LevelState GetPrev()
    {
        return _prev;
    }

    public void SetCurr(LevelState ls) {
        _curr = ls;
    }
}
