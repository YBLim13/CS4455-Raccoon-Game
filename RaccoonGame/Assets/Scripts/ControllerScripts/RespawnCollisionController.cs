using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCollisionController : MonoBehaviour
{
    private Vector3 _relPos;
    private Quaternion _relRot;

    private void Awake() {
        _relPos = this.transform.localPosition;
    }

    private void Update() {
        this.transform.localPosition = _relPos;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            RespawnManager.Instance.Respawn();
            CarSpawnerManager.Instance.ResetCars();
        }
    }
}
