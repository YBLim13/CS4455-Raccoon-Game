using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkyardStartupManager : MonoBehaviour
{
    private static JunkyardStartupManager _instance;
    public static JunkyardStartupManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("JunkyardStartupManager has yet to be created");
            }

            return _instance;
        }
    }

    [SerializeField]
    private GameObject _cityGate;
    [SerializeField]
    private GameObject _townCenterGate;
    [SerializeField]
    private GameObject _cityGateCollider;
    [SerializeField]
    private GameObject _townCenterGateCollider;
    [SerializeField]
    private Camera _cityGateCam;
    [SerializeField]
    private Camera _townCenterGateCam;
    [SerializeField]
    private CanvasGroup _canvas;
    [SerializeField]
    private GameObject _mainPanel;
    [SerializeField]
    private GameObject _cornerPanel;
    
    private LevelStateManager.LevelState prev;


    private void Awake()
    {
        prev = LevelStateManager.Instance.GetPrev();
    }

    // Start is called before the first frame update
    void Start()
    {
        bool alreadyIntro = false;
        int numItems = InventoryManager.Instance.inventory.Count;

        if (numItems >= 8) {
            _townCenterGate.transform.Rotate(new Vector3(-90, 0, 0));
            Destroy(_townCenterGateCollider);

            if (CutsceneManager.Instance.isTownCenterGateClosed()) {
                alreadyIntro = true;
                if (prev == LevelStateManager.LevelState.Home_Scene) {
                    CutsceneManager.Instance.setIsTownCenterGateClosed(false);
                    StartCoroutine(TurnOnCamera(_townCenterGateCam));
                } else {
                    StartCoroutine(IntroArea());
                }
            }
        }
        if (numItems >= 3) {
            _cityGate.transform.Rotate(new Vector3(-90, 0, 0));
            Destroy(_cityGateCollider);

            if (CutsceneManager.Instance.isCityGateClosed()) {
                alreadyIntro = true;
                if (prev == LevelStateManager.LevelState.Home_Scene) {
                    CutsceneManager.Instance.setIsCityGateClosed(false);
                    StartCoroutine(TurnOnCamera(_cityGateCam));
                } else {
                    StartCoroutine(IntroArea());
                }
            }
        }
        if ((numItems < 3 || !CutsceneManager.Instance.isCityGateClosed()) && !alreadyIntro) {
            StartCoroutine(IntroArea());
        }    
    }

    IEnumerator TurnOnCamera(Camera cam) {
        CutsceneManager.Instance.setIsCutscene(true);
        yield return new WaitForSeconds(0.5f);
        cam.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        cam.gameObject.SetActive(false);
        CutsceneManager.Instance.setIsCutscene(false);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(IntroArea());
    }

    IEnumerator IntroArea() {
        while (_canvas.alpha < 1) {
            _canvas.alpha += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3f);    // Hold the center panel for 3 sec
        while (_canvas.alpha > 0) {
            _canvas.alpha -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        _mainPanel.SetActive(false);
        _cornerPanel.SetActive(true);

        while (_canvas.alpha < 1) {
            _canvas.alpha += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
