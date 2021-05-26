using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityAndCHAllStartupManager : MonoBehaviour
{
    private static CityAndCHAllStartupManager _instance;
    public static CityAndCHAllStartupManager Instance
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
    private CanvasGroup _canvas;
    [SerializeField]
    private GameObject _mainPanel;
    [SerializeField]
    private GameObject _cornerPanel;


    // Start is called before the first frame update
    void Start()
    {
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
