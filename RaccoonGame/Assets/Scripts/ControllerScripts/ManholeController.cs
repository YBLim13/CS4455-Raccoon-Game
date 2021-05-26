using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    private bool _isRising;
    [SerializeField]
    private Collider _collider;

    public float threshold = -5;

    private void Start() {
        _rb.isKinematic = true;
        _isRising = false;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            _rb.isKinematic = false;
            _rb.useGravity = true;
            _rb.AddForce(Vector3.down, ForceMode.Impulse);
        }
    }
    private void Update() {
        if (this.transform.position.y <= threshold && !_isRising) {
            _rb.isKinematic = true;
            _rb.useGravity = false;
            _collider.enabled = false;
            _isRising = true;
            StartCoroutine("FixPosition");
        }
    }

    IEnumerator FixPosition() {
        while (this.transform.position.y < 0.6f) {
            float xVal = this.transform.position.x;
            float yVal = this.transform.position.y;
            float zVal = this.transform.position.z;
            this.transform.position = new Vector3(xVal, yVal + 0.2f, zVal);
            if (this.transform.position.y > 0.6f) {
                this.transform.position = new Vector3(xVal, 0.6f, zVal);
            }
            yield return new WaitForSeconds(0.02f);
        }
        _isRising = false;
        _collider.enabled = true;
    }
}
