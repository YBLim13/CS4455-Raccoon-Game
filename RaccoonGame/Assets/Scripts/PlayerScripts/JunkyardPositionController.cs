using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkyardPositionController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _initPositionQuit;
    [SerializeField]
    private Quaternion _initRotaionQuit;

    [SerializeField]
    private Vector3 _initPositionCity;
    [SerializeField]
    private Quaternion _initRotaionCity;

    [SerializeField]
    private Vector3 _initPositionCenter;
    [SerializeField]
    private Quaternion _initRotaionCenter;

    [SerializeField]
    private Vector3 _initPositionHome;
    [SerializeField]
    private Quaternion _initRotaionHome;

    private void Awake() {
        LevelStateManager.LevelState prev = LevelStateManager.Instance.GetPrev();

        switch(prev) {
            case LevelStateManager.LevelState.Home_Screen:
                this.transform.position = _initPositionQuit;
                this.transform.rotation = _initRotaionQuit;
                break;
            case LevelStateManager.LevelState.City:
                this.transform.position = _initPositionCity;
                this.transform.rotation = _initRotaionCity;
                break;
            case LevelStateManager.LevelState.Town_Center:
                this.transform.position = _initPositionCenter;
                this.transform.rotation = _initRotaionCenter;
                break;
            case LevelStateManager.LevelState.Home_Scene:
                this.transform.position = _initPositionHome;
                this.transform.rotation = _initRotaionHome;
                break;
        }
    }
}
