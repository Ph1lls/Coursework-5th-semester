using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class ConditionChecker : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject[] requiredItems; 
    [SerializeField] private Button checkConditionsButton;
    [SerializeField] public UnityEvent customEvent;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if (checkConditionsButton != null)
        {
            checkConditionsButton.gameObject.SetActive(false); 
            checkConditionsButton.onClick.AddListener(CheckConditions); 
        }
    }


    public void CheckConditions()
    {
        bool allItemsFound = true;

        foreach (GameObject requiredItem in requiredItems)
        {
            bool itemFound = false;

            foreach (GameObject item in inventory.prefabs)
            {
                if (item != null)
                {
                    string itemName = item.name;

                    if (itemName.EndsWith("(Clone)"))
                    {
                        itemName = itemName.Substring(0, itemName.Length - 7); 
                    }

                    if (itemName == requiredItem.name)
                    {
                        itemFound = true;
                        break;  
                    }
                }
            }

            if (!itemFound)
            {
                allItemsFound = false;
                break;
            }
        }

        if (allItemsFound)
        {

            dialogueManager?.StartDialogue();
            customEvent.Invoke();

        }
        else
        {
            dialogueManager?.StartDialogue();
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            if (checkConditionsButton != null)
            {
                checkConditionsButton.gameObject.SetActive(true);  
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            if (checkConditionsButton != null)
            {
                checkConditionsButton.gameObject.SetActive(false); 
            }
        }
    }
}
