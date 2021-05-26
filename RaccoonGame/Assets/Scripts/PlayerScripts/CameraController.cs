using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = new Vector3(0.0f, 10.3f, -10.5f);

    }

    void LateUpdate()
    {
        this.transform.position = player.transform.position + _offset;
    }
}
