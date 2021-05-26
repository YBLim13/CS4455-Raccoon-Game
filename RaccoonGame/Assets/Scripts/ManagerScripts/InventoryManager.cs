using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("InventoryManager has yet to be created");
            }

            return _instance;
        }
    }

    //[SerializeField]
    //private int maxSpace = 10;
    [SerializeField]
    private int numItems = 0;
    public int foodCount = 0;
    public int healthCount = 3;
    public List<string> inventory = new List<string>();
    public AudioSource pickup;
    public AudioSource healthUp;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }


    //// Start is called before the first frame update
    //static void Start()
    //{
    //    //inventory = new List<GameObject>();
    ///

    public string GetNames()
    {
        if (numItems == 0)
        {
            return "";
        }

        string[] arrayInventory = inventory.ToArray();
        string temp = arrayInventory[0];

        for (int i = 1; i < numItems; i++)
        {
            temp = temp + ", " + arrayInventory[i];
        }

        return temp;
    }

    public bool AddItem(GameObject obj)
    {
        //if (numItems >= inventoryCapacity) {
        //    return false;
        //} else {
        pickup.Play();
        inventory.Add(obj.GetComponent<ItemName>().name);
        numItems++;
        return true;
        //}
    }

    public void LoadItems(List<string> items)
    {
        inventory.Clear();
        foreach (string item in items)
        {
            inventory.Add(item);
        }
    }

    public GameObject DropItem(int index = 0)      // Temporarily set to 0, later can be set to whatever
    {
        if (numItems == 0 || index >= numItems)
        {
            return null;
        }

        //GameObject[] temp = new GameObject[maxSpace];
        //GameObject returnedObj = inventory[index];
        //int offset = 0;

        //for (int i = 0; i < numItems; i++) {
        //    if (i == index) {
        //        offset = -1;
        //        continue;
        //    }

        //    temp[i + offset] = inventory[i];
        //}

        //numItems--;
        inventory.RemoveAt(index);

        //return inventory[index];
        return null;
    }

    public void NewGame()
    {
        inventory = new List<String>();
        healthCount = 3;
    }

    public void AddFood()
    {
        foodCount++;
    }

    public void LoadFood(int count)
    {
        foodCount = count;
    }

    public void LoadHealth(int count)
    {
        healthCount = count;
    }

    public void AddHealth()
    {
        if (healthCount >= 3)
        {
            healthCount = 3;
        }
        else
        {
            healthUp.Play();
            healthCount++;
        }

    }

    public void SubHealth()
    {
        healthCount--;
    }


    //public void IncreaseInventoryCapacity(int increaseAmount)
    //{
    //    Array.Resize<GameObject>(ref inventory, inventoryCapacity + increaseAmount);
    //}
    //make cases to test if inventory is full

}
