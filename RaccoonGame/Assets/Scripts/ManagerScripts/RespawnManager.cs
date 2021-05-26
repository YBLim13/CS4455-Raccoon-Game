using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private static RespawnManager _instance;
    public static RespawnManager Instance
    {
        get
        {
            if (_instance == null) {
                Debug.LogError("RespawnManager has not been created.");
            }

            return _instance;
        }
    }

    [SerializeField]
    private GameObject _player;
    public Vector3 _startPos;
    public Quaternion _startRot;
    public Vector3 tempPos;
    public Quaternion tempRot;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }

    public void StartOver() {
        _player.transform.localPosition = _startPos;
        _player.transform.localRotation = _startRot;
    }

    public void Respawn() {
        _player.transform.localPosition = tempPos;
        _player.transform.localRotation = tempRot;
    }
}
