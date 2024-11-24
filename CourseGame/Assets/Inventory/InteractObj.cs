using UnityEngine;

public class InteractObj : MonoBehaviour
{
    public DialogueManager nearestTrigger;

    void Update()
    {
        if (nearestTrigger is not null)
        {
            if (Input.GetKey(KeyCode.F))
            {
                nearestTrigger.StartDialogue();
            }
        }
    }
}