using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueLine dialogueSystem; // Reference to DialogueLine
    [SerializeField] private string[] dialogueLines;     // NPC's lines

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Pass the NPC's lines to the dialogue system
            dialogueSystem.lines = dialogueLines;
            dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueSystem.gameObject.SetActive(false);
        }
    }
}