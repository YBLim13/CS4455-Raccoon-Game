using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCenterPositionController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _initPositionJunkyard;
    [SerializeField]
    private Quaternion _initRotationJunkyard;

    [SerializeField]
    private Vector3 _initPositionCityHall;
    [SerializeField]
    private Quaternion _initRotationCityHall;

    private void Awake() {
        LevelStateManager.LevelState prev = LevelStateManager.Instance.GetPrev();

        switch(prev) {
            case LevelStateManager.LevelState.Junkyard:
                this.transform.position = _initPositionJunkyard;
                this.transform.rotation = _initRotationJunkyard;
                break;
            case LevelStateManager.LevelState.City_Hall:
                this.transform.position = _initPositionCityHall;
                this.transform.rotation = _initRotationCityHall;
                break;
        }
    }
}
