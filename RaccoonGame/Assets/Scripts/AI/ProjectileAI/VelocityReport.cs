using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityReport : MonoBehaviour
{

    public Vector3 lastFramePos;
    public Vector3 playerVelocity;
    // Start is called before the first frame update
    void Start()
    {
        lastFramePos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerVelocity = (transform.position - lastFramePos) / Time.deltaTime;
        lastFramePos = transform.position;
    }
}
