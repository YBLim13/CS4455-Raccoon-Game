using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTextController : MonoBehaviour
{
    public Text areaText;
    public string areaName = "The Junkyard";

    // Start is called before the first frame update
    void Start()
    {
        areaText.text = "~~" + areaName + "~~";
    }
}
