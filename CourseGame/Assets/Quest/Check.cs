using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ConditionChecker : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private SceneCondition[] sceneConditions;
    [SerializeField] private Button checkConditionsButton;

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
        foreach (var condition in sceneConditions)
        {
            if (AreItemsInInventory(condition.requiredItems))
            {
                dialogueManager?.StartDialogue();
                condition.customEvent.Invoke();
                return;
            }
        }

        dialogueManager?.StartDialogue();
    }

    private bool AreItemsInInventory(GameObject[] requiredItems)
    {
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
                return false;
            }
        }

        return true;
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

[System.Serializable]
public class SceneCondition
{
    public GameObject[] requiredItems;
    public UnityEvent customEvent;
}
