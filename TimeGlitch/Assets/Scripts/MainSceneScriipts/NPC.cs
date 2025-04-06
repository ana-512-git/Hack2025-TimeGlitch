using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueLine dialogueSystem; // Reference to DialogueLine
    [SerializeField] private string[] dialogueLines;     // NPC's lines
    [SerializeField] private bool replays;
    [SerializeField] private bool hasPlayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (!hasPlayed || replays))
        {
            // Pass the NPC's lines to the dialogue system
            dialogueSystem.lines = dialogueLines;
            dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue();
            hasPlayed = true;
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