using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCTextController : MonoBehaviour
{
    private GameObject[][] panels = new GameObject[3][];
    [SerializeField]
    private GameObject[] panels_0 = new GameObject[5];
    [SerializeField]
    private GameObject[] panels_1 = new GameObject[2];
    [SerializeField]
    private GameObject[] panels_2 = new GameObject[3];
    [SerializeField]
    private AudioSource _audio;

    private int index_first = 0;
    private int index_second = 0;
    private int index_second_length;
    private int numItems;

    private void Awake()
    {
        panels[0] = panels_0;
        panels[1] = panels_1;
        panels[2] = panels_2;

        foreach (GameObject[] panel in panels) {
            foreach (GameObject text in panel) {
                text.SetActive(false);
            }
        }
    }

    private void Start() {
        numItems = InventoryManager.Instance.inventory.Count;

        if (numItems == 0 && !CutsceneManager.Instance.hadStartGameScene()) {
            CutsceneManager.Instance.setIsCutscene(true);
            CutsceneManager.Instance.setHadStartGameScene(true);
            index_first = 0;
            index_second_length = 5;
        } else if (numItems == 14 && !CutsceneManager.Instance.hadMidGameScene()) {
            CutsceneManager.Instance.setIsCutscene(true);
            CutsceneManager.Instance.setHadMidGameScene(true);
            index_first = 1;
            index_second_length = 2;
            CutsceneManager.Instance.setDelivered14(true);
        } else if (numItems == 15 && !CutsceneManager.Instance.hadEndGameScene()) {
            CutsceneManager.Instance.setIsCutscene(true);
            CutsceneManager.Instance.setHadEndGameScene(true);
            index_first = 2;
            index_second_length = 3;
        } else {
            CutsceneManager.Instance.setIsCutscene(false);
        }

        if (CutsceneManager.Instance.isCutscene()) {
            panels[index_first][index_second].SetActive(true);
        }
    }

    private void OnNextText() {
        if (index_second < index_second_length && CutsceneManager.Instance.isCutscene()) {
            panels[index_first][index_second].SetActive(false);
            index_second++;

            if (index_second != index_second_length) {
                panels[index_first][index_second].SetActive(true);
            }
        }

        if (index_second == index_second_length) {
            CutsceneManager.Instance.setIsCutscene(false);

            if (index_first == 2) {
                StartCoroutine(DropVolume());
                int _sceneIndex = LevelStateManager.Instance.ChangeState(LevelStateManager.LevelState.Win_Screen);
                //SceneManager.LoadScene(_sceneIndex);
            }
        }
    }

    IEnumerator DropVolume() {
        float currVol = _audio.volume;
        while (_audio.volume > 0) {
            _audio.volume -= currVol/10;
            yield return new WaitForSeconds(0.1f);
        }
    }
}