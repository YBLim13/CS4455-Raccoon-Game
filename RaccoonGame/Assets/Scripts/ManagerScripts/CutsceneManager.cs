using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    private static CutsceneManager _instance;
    public static CutsceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("CutsceneManager has not been created.");
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
    }

    [SerializeField]
    private bool  _isCutscene = true;
    [SerializeField]
    private bool _hadStartGameScene = false;
    [SerializeField]
    private bool _hadMidGameScene = false;
    [SerializeField]
    private bool _hadEndGameScene = false;

    // For junkyard scene use only
    [SerializeField]
    private bool  _isCityGateClosed = true;
    [SerializeField]
    private bool  _isTownCenterClosed = true;

    // For town hall scene use only
    [SerializeField]
    private bool _isCityHallDoorClosed = true;
    private bool _delivered14 = false;

    public bool isCutscene() {
        return _isCutscene;
    }

    public void setIsCutscene(bool val) {
        _isCutscene = val;
    }

    public bool isCityGateClosed() {
        return _isCityGateClosed;
    }

    public void setIsCityGateClosed(bool val) {
        _isCityGateClosed = val;
    }

    public bool isTownCenterGateClosed() {
        return _isTownCenterClosed;
    }

    public void setIsTownCenterGateClosed(bool val) {
        _isTownCenterClosed = val;
    }

    public bool isCityHallDoorClosed() {
        return _isCityHallDoorClosed;
    }

    public void setIsCityHallDoorClosed(bool val) {
        _isCityHallDoorClosed = val;
    }

    public bool hadStartGameScene() {
        return _hadStartGameScene;
    }

    public void setHadStartGameScene(bool val) {
        _hadStartGameScene = val;
    }

    public bool hadMidGameScene() {
        return _hadMidGameScene;
    }

    public void setHadMidGameScene(bool val) {
        _hadMidGameScene = val;
    }

    public bool hadEndGameScene() {
        return _hadEndGameScene;
    }

    public void setHadEndGameScene(bool val) {
        _hadMidGameScene = val;
    }

    public bool hasDelivered14() {
        return _delivered14;
    }

    public void setDelivered14(bool val) {
        _delivered14 = val;
    }

    public void NewGame() {
        _isCutscene = true;
        _hadStartGameScene = false;
        _hadMidGameScene = false;
        _hadEndGameScene = false;
        _isCityGateClosed = true;
        _isTownCenterClosed = true;
        _isCityHallDoorClosed = true;
    }
}
