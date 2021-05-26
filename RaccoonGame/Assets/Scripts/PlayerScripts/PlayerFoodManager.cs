// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using TMPro;

// public class PlayerFoodManager : MonoBehaviour
// {
//     public TextMeshProUGUI foodCountText;
//     int foodCount;
 
//     private static PlayerFoodManager _instance;
//     public static PlayerFoodManager Instance
//     {
//         get
//         {
//             if (_instance == null)
//             {
//                 Debug.LogError("PlayerFoodManager has yet to be created");
//             }

//             return _instance;
//         }
//     }
//     void Start()
//     {
//         setCountText();
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     void setCountText()
//     {
//         foodCountText.text = "Food Count: " + foodCount.ToString();

//     }
// }
