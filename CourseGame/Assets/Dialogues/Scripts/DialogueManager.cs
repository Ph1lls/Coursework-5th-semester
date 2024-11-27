using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text dialogueText; 
    [SerializeField] private Text nameText;
    [SerializeField] private Image dialogueImage; 
    [SerializeField] private Dialogue dialogue; 

    [SerializeField] private animateBox boxAnim; 
    [SerializeField] private Interactor startAnim; 

    private InteractObj player; 

    private Queue<string> sentences; 
    private bool isDisplayingSentence = false; 
    private bool isInDialogue = false;

    private void Start()
    {
        sentences = new Queue<string>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractObj>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (startAnim != null)
        {
            startAnim.Move(true);
            player.nearestTrigger = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (startAnim != null)
        {
            startAnim.Move(false);
        }

        player.nearestTrigger = null;


        if (!isInDialogue)
        {
            EndDialogue();
        }
    }

    public void StartDialogue()
    {
        if (dialogue == null || dialogue.sentences.Length == 0)
        {
            return;
        }

        isInDialogue = true; 

        boxAnim.Move(true); 

        if (startAnim != null)
        {
            startAnim.Move(false);
        }

        nameText.text = dialogue.name;
        sentences.Clear();
        if (dialogue.pic != null)
        {
            dialogueImage.sprite = dialogue.pic;
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(); 
    }

    public void DisplayNextSentence()
    {
        
        if (isDisplayingSentence)
            return;


        if (sentences.Count == 0)
        {
            EndDialogue(); 
            return;
        }

        string sentence = sentences.Dequeue(); 

        StopAllCoroutines();
        StartCoroutine(TS(sentence)); 
    }

    private IEnumerator TS(string sentence)
    {
        isDisplayingSentence = true; 

        dialogueText.text = ""; 
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; 
        }

        isDisplayingSentence = false; 
    }

    private void EndDialogue()
    {
        if (!isInDialogue) return; 

        isInDialogue = false;
        boxAnim.Move(false);
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            if (isInDialogue && !isDisplayingSentence)
            {
                DisplayNextSentence();
            }
        }
    }
}
