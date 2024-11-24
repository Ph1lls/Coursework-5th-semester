using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public UnityEvent customEvent;

    [SerializeField] private GameObject slotButton;
    private bool playerInRange = false;

    [SerializeField] private Button handButton; 
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private Interactor startAnim;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

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

    private void AddItemToInventory()
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
                Instantiate(slotButton, inventory.slots[i].transform);
                inventory.prefabs[i] = slotButton;
                handButton.interactable = false;
                break;
            }
        }

        
    }

    public void OnHandButtonClick()
    {
        AddItemToInventory();
        customEvent.Invoke();
    }
}
