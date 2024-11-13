using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAT : MonoBehaviour
{
    public Animator startAnim_t;
    public DialogueManager_tomato1 dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnim_t.SetBool("startOpen_t", true);
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim_t.SetBool("startOpen_t", false);
        dm.EndDialogue();
    }
}
