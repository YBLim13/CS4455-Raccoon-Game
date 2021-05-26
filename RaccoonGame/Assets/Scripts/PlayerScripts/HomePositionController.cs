using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePositionController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _initPositionStart;
    [SerializeField]
    private Quaternion _initRotaionStart;

    [SerializeField]
    private Vector3 _initPositionNorm;
    [SerializeField]
    private Quaternion _initRotaionNorm;

    private void Start() {
        bool cutscene = CutsceneManager.Instance.isCutscene();

        if (cutscene) {
            this.transform.position = _initPositionStart;
            this.transform.rotation = _initRotaionStart;
        } else {
            this.transform.position = _initPositionNorm;
            this.transform.rotation = _initRotaionNorm;
        }
    }
}
