using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrailerCameraController : MonoBehaviour
{
    public int speed = 5;
    public int rotSpeed = 20;
    private float _yVal;

    // Start is called before the first frame update
    void Start()
    {
        _yVal = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            this.gameObject.transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.gameObject.transform.Rotate(Vector3.down * rotSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            this.gameObject.transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            this.gameObject.transform.Rotate(Vector3.left * rotSpeed * Time.deltaTime);
        }

        this.transform.position = new Vector3(this.transform.position.x, _yVal, this.transform.position.z);

        if (Input.GetKey(KeyCode.Alpha2)) {
            SceneManager.LoadScene(2);
        } else if (Input.GetKey(KeyCode.Alpha3)) {
            SceneManager.LoadScene(3);
        } else if (Input.GetKey(KeyCode.Alpha4)) {
            SceneManager.LoadScene(4);
        } else if (Input.GetKey(KeyCode.Alpha5)) {
            SceneManager.LoadScene(5);
        } 
    }
}
