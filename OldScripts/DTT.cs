using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript_t : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager_tomato1>().StartDialogue(dialogue);
    }
}
