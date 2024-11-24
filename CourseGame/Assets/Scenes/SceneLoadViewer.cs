using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadViewer : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;

    private void Awake()
    {
        ReshowInventory(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>());
    }

    private void ReshowInventory(Inventory inventory)
    {
        inventory.transform.position = new Vector3(0, -1.06f, -3);
        inventory.slots = slots;
        for (int i = 0; i < inventory.prefabs.Length; i++)
        {
            if (inventory.prefabs[i] is not null)
            {
                Instantiate(inventory.prefabs[i], inventory.slots[i].transform);
            }
        }
    }
}
