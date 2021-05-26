using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeLoader : MonoBehaviour
{
    public GameObject decorationsHolder;

    private bool _hasTable = false;
    private bool _hasTV = false;
    [SerializeField]
    private GameObject Radio;
    [SerializeField]
    private GameObject Vase2;

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
            child.gameObject.SetActive(false);
            decorations.Add(name, child.gameObject);
        }

        //List<string> inv = new List<string>();
        //inv.Add("radio");
        List<string> inventory = InventoryManager.Instance.inventory;

        foreach (string item in inventory)
        {
            if (item.Equals("Table")) {
                _hasTable = true;
            }
            if (item.Equals("TV")) {
                _hasTV = true;
            }

            GameObject obj = decorations[item];
            if(item!=null)
            {
                obj.SetActive(true);
            }
        }

        if (!_hasTable && Radio.activeInHierarchy) {
            Vector3 pos = Radio.transform.position;
            Radio.transform.position = new Vector3(pos.x, 0.6f, pos.z);
        }
        if (!_hasTV && Vase2.activeInHierarchy) {
            Vector3 pos = Vase2.transform.position;
            Vase2.transform.position = new Vector3(pos.x, 0.5f, pos.z);
        }
    }
}
