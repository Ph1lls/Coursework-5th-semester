using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public GameObject[] slots;
    public GameObject[] prefabs;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this; 
        }
    }

    public void SaveInventory()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            if (prefabs[i] != null)
            {
                PlayerPrefs.SetString("Item" + i, prefabs[i].name);  
            }
            else
            {
                PlayerPrefs.SetString("Item" + i, string.Empty);
            }
        }
        PlayerPrefs.Save();
    }
    public void LoadInventory()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            string itemName = PlayerPrefs.GetString("Item" + i);
            if (!string.IsNullOrEmpty(itemName))
            {
                GameObject item = Resources.Load<GameObject>("Items/" + itemName); 
                prefabs[i] = item;  
            }
            else
            {
                prefabs[i] = null;
            }
        }
    }
}
