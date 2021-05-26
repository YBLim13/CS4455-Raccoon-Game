using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public GameObject prefab;

    public void Init()
    {
        List<string> items = InventoryManager.Instance.inventory;
        GridLayoutGroup table = GetComponent<GridLayoutGroup>();
        //print(items.Count);


        if (items.Count == 0)
        {
            //todo set text to no items in invetory
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                addEntry(items[i]);
            }
        }
    }

    public void Close()
    {
        GridLayoutGroup table = GetComponent<GridLayoutGroup>();
        for (int i = table.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(table.transform.GetChild(i).gameObject);
        }
    }

    private void addEntry(string item)
    {
        GameObject entry = Instantiate(prefab);
        entry.transform.Find("Item Name").GetComponent<Text>().text = item;

        Texture image = Resources.Load("collectibles/" + item) as Texture;
        print(image);
        entry.transform.Find("Item Image").GetComponent<RawImage>().texture = image;

        entry.transform.SetParent(this.gameObject.transform);

    }
}
