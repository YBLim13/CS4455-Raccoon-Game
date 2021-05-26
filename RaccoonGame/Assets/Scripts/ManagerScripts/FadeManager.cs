using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    private static FadeManager _instance;
    public static FadeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("FadeManager has not been created.");
            }

            return _instance;
        }
    }

    [SerializeField]
    private CanvasGroup _fadeUI;
    [SerializeField]
    private Animator _anim;
    private bool _fadeLock = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }

    public void TriggerFadeOut(int nextScene) {
        LevelStateManager.LevelState curr = LevelStateManager.Instance.GetCurr();
        StartCoroutine(FadeOut(nextScene));
    }

    public bool isFadeLocked() {
        return _fadeLock;
    }

    public void setFadeLock(bool val) {
        _fadeLock = val;
    }

    IEnumerator FadeOut(int nextScene) {
        _anim.SetBool("NewScene", false);
        _anim.SetBool("TriggerTransition", true);
        yield return new WaitUntil(() => _fadeUI.alpha == 1);
        SceneManager.LoadScene(nextScene);
        _anim.SetBool("TriggerTransition", false);
        _anim.SetBool("NewScene", true);
        _fadeLock = false;
    }
}
