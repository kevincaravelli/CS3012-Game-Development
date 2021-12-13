using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        gameObject.tag = "active";
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.tag = "active";
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void removeObject()
    {
        Destroy(gameObject);
    }
}
