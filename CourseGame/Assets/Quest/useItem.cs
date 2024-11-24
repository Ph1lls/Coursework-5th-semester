using UnityEngine;

public class useItem : MonoBehaviour
{
    [SerializeField] private Inventory inventory;          
    [SerializeField] private DialogueManager dialogueManagerRight;
    [SerializeField] private DialogueManager dialogueManagerFalse;
    [SerializeField] private GameObject itemGoalPrefab;       
    [SerializeField] private GameObject itemNeedPrefab;       

    private bool playerInRange = false; 
    private int selectedSlot = -1;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); 
    }

    private void Update()
    {
       
        if (playerInRange && selectedSlot >= 0 && Input.GetKeyDown(KeyCode.E))
        {
            HandleItemInteraction();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            selectedSlot = -1; 

        }
    }

    public void SelectSlot(int slotIndex)
    {
        if (playerInRange)
        {
            selectedSlot = slotIndex;
        }
    }

    private void HandleItemInteraction()
    {
        if (selectedSlot < 0 || selectedSlot >= inventory.slots.Length) return;

        GameObject selectedItem = inventory.prefabs[selectedSlot];

        if (selectedItem != null && selectedItem == itemNeedPrefab)
        {
            ReplaceItemInSlot(selectedSlot, itemGoalPrefab);

            if (dialogueManagerRight != null)
            {
                dialogueManagerRight.StartDialogue();
            }
        }

        else 
        {
            if (dialogueManagerFalse != null)
            {
                dialogueManagerFalse.StartDialogue();
            }
        }
    }

    private void ReplaceItemInSlot(int slotIndex, GameObject newItem)
    {
        Destroy(inventory.prefabs[slotIndex]);

        for (int i = slotIndex; i < inventory.slots.Length - 1; i++)
        {
            inventory.prefabs[i] = inventory.prefabs[i + 1];
        }
        inventory.prefabs[inventory.slots.Length - 1] = Instantiate(newItem, inventory.slots[slotIndex].transform);
    }
}
