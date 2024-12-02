using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            dialogueManager.StartDialogue();
        }
    }
}
