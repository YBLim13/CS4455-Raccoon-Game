using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public TextMeshProUGUI foodCountText;
    // Start is called before the first frame update
    void Start()
    {
        updateFood();
    }

    // Update is called once per frame
    void Update()
    {
        updateFood();
    }

    private void updateFood()
    {
        foodCountText.text = "Food Count: " + InventoryManager.Instance.foodCount.ToString();
    }
}
