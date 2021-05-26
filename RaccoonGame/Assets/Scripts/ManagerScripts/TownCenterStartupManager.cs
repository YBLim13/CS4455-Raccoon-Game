using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCenterStartupManager : MonoBehaviour
{
    private static TownCenterStartupManager _instance;
    public static TownCenterStartupManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("TownCenterTransitionManager has yet to be created");
            }

            return _instance;
        }
    }

    [SerializeField]
    private GameObject _cityHallDoorL;
    [SerializeField]
    private GameObject _cityHallDoorR;
    [SerializeField]
    private Camera _cityHallCam;
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

        if (numItems >= 14 && CutsceneManager.Instance.hasDelivered14()) {
            _cityHallDoorL.transform.Rotate(new Vector3(0, 120, 0));
            _cityHallDoorR.transform.Rotate(new Vector3(0, -120, 0));
            
            if (CutsceneManager.Instance.isCityHallDoorClosed()) {
                alreadyIntro = true;
                if (prev == LevelStateManager.LevelState.Junkyard) {
                    CutsceneManager.Instance.setIsCityHallDoorClosed(false);
                    StartCoroutine(TurnOnCamera(_cityHallCam));
                } else {
                    StartCoroutine(IntroArea());
                }
            }
        }
        if ((numItems < 14 || !CutsceneManager.Instance.isCityHallDoorClosed() || 
            !CutsceneManager.Instance.hasDelivered14()) && !alreadyIntro) {
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
