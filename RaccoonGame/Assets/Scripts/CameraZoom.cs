using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _canvas;
    [SerializeField]
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartZoom());
    }

    IEnumerator StartZoom() {
        Vector3 pos = this.transform.position;

        while (pos.z < -13.5) {
            this.transform.position = new Vector3(pos.x, pos.y, pos.z + 0.05f);
            pos = this.transform.position;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(ThankPlayer());
    }

    IEnumerator ThankPlayer() {
        while (_canvas.alpha < 1) {
            _canvas.alpha += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(DropVolume());
        yield return new WaitForSeconds(1f);
        LevelStateManager.Instance.ChangeState(LevelStateManager.LevelState.Home_Screen);
    }

    IEnumerator DropVolume() {
        float currVol = _audio.volume;
        while (_audio.volume > 0) {
            _audio.volume -= currVol/10;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
