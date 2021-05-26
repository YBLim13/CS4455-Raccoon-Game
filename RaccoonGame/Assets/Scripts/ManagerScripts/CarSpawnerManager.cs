using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerManager : MonoBehaviour
{
    private static CarSpawnerManager _instance;
    public static CarSpawnerManager Instance
    {
        get
        {
            if (_instance == null) {
                Debug.LogError("CarSpawnManager has not been created.");
            }

            return _instance;
        }
    }

    public float spawnWaitVal = 2.0f;

    [SerializeField]
    private GameObject[] _RLCars;
    [SerializeField]
    private GameObject[] _LRCars;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void Start()
    {
        StartCars();
    }

    public void ResetCars() {
        StopAllCoroutines();

        for (int i = _RLCars.Length - 1; i >= 0; i--) {
            _RLCars[i].SetActive(false);
        }
        for (int i = _LRCars.Length - 1; i >= 0; i--) {
            _LRCars[i].SetActive(false);
        }

        StartCars();
    }

    public void StartCars() {
        StartCoroutine(StartSpawn(_RLCars));
        StartCoroutine(StartSpawn(_LRCars));
    }

    IEnumerator StartSpawn(GameObject[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            arr[i].SetActive(true);
            yield return new WaitForSeconds(spawnWaitVal);
        }
    }
}
