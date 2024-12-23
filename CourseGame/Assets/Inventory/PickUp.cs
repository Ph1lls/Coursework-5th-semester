using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public UnityEvent customEvent;

    [SerializeField] private GameObject slotButton;
    private GameObject itemInSlot = null;
    private bool playerInRange = false;

    [SerializeField] private Button handButton;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private Interactor startAnim;

    private void Start()
    {
        inventory = Inventory.Instance; 
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            AddItemToInventory();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
        startAnim.Move(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
        startAnim.Move(false);
    }

    public void AddItemToInventory()
    {
        startAnim.Move(false);
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue();
        }

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.prefabs[i] == null)
            {
                itemInSlot = Instantiate(slotButton, inventory.slots[i].transform);
                inventory.prefabs[i] = itemInSlot;
                inventory.prefabs[i].SetActive(true);
                handButton.interactable = false;
                break;
            }
        }

       
        customEvent.Invoke();
    }

    public void OnHandButtonClick()
    {
        AddItemToInventory();
    }
}
