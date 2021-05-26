using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject target;
    public Vector3 rotationAmount;
    

    // Update is called once per frame
    void Update()
    {
        this.target.transform.Rotate(rotationAmount * Time.deltaTime);
    }
}
