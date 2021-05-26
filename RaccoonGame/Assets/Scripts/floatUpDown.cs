using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 1f;
    float delta = 3f;  //delta is the difference between min y to max y.
    public GameObject thing;

    void Update() {
         float y = transform.position.y + Mathf.PingPong(speed * Time.time, delta); 
         Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
         this.thing.transform.position = pos;
    }
}
