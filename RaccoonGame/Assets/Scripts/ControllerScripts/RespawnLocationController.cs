using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLocationController : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            RespawnManager.Instance.tempPos = position;
            RespawnManager.Instance.tempRot = rotation;
        }
    }
}
