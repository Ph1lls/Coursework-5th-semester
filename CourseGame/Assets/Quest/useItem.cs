using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;  
public class useItem : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private DialogueManager dialogueManagerRight;
    [SerializeField] private DialogueManager dialogueManagerFalse;
    [SerializeField] private GameObject itemGoalPrefab;
    [SerializeField] private GameObject itemNeedPrefab;

    private bool playerInRange = false;
    private int selectedSlot = -1;
    public UnityEvent customEvent;

    [SerializeField] private Button[] inventoryButtons;
    [SerializeField] private Button useButton; 

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        for (int i = 0; i < inventoryButtons.Length; i++)
        {
            int index = i;
            inventoryButtons[i].onClick.AddListener(() => SelectSlot(index));
        }

        if (useButton != null)
        {
            useButton.onClick.AddListener(HandleItemInteraction); 
        }
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
        if (selectedSlot < 0 || inventory.prefabs[selectedSlot] == null)
        {
            if (dialogueManagerFalse != null)
            {
                dialogueManagerFalse.StartDialogue();
            }
            return; 
        }

        if (selectedSlot >= 0 && selectedSlot < inventory.slots.Length)
        {
            GameObject selectedItem = inventory.prefabs[selectedSlot];
            string gselectedItem = selectedItem.name.Replace("(Clone)", "");

            if (selectedItem != null && gselectedItem == itemNeedPrefab.name)
            {
                DeactivateItemInSlot(selectedSlot);
                ReplaceItemInSlot(selectedSlot, itemGoalPrefab);

                if (dialogueManagerRight != null)
                {
                    dialogueManagerRight.StartDialogue();
                }
                customEvent.Invoke();
            }
            else
            {
                if (dialogueManagerFalse != null)
                {
                    dialogueManagerFalse.StartDialogue();
                }
            }
        }
    }

    private void DeactivateItemInSlot(int slotIndex)
    {
        if (inventory.prefabs[slotIndex] != null)
        {
            inventory.prefabs[slotIndex].SetActive(false);
        }
    }

    private void ReplaceItemInSlot(int slotIndex, GameObject newItem)
    {
        if (inventory.prefabs[slotIndex] != null)
        {
            inventory.prefabs[slotIndex].SetActive(false); 
        }

        GameObject newObject = Instantiate(newItem, inventory.slots[slotIndex].transform);
        inventory.prefabs[slotIndex] = newObject;
        newObject.SetActive(true);
    }
}
