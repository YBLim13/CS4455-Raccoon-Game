using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject decorationsHolder;
    // Start is called before the first frame update
    void Start()
    {
        //inventory = InventoryManager.Instance.inventory;
        //for(int i = 0; i<inventory.Count; i++)
        //{
        //    string currObj = inventory[i];
        //    Transform decoration = decorationsHolder.transform.Find(currObj);
        //    if (decoration != null)
        //    {
        //        decoration.gameObject.SetActive(true);
        //    }
        //}

        Dictionary<string, GameObject> decorations = new Dictionary<string, GameObject>();
        foreach (Transform child in decorationsHolder.transform)
        {
            string name = child.GetComponent<ItemName>().itemName;
            decorations.Add(name, child.gameObject);
        }

        //List<string> inv = new List<string>();
        //inv.Add("radio");
        List<string> inventory = InventoryManager.Instance.inventory;

        foreach (string item in inventory)
        {
            GameObject value;
            if (item != null && decorations.TryGetValue(item, out value))
            {
                GameObject obj = decorations[item];
                obj.SetActive(false);
            }
        }
    }
}
