using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneChangerScript: MonoBehaviour
{
    [Header("Dialogue Settings")]
    [SerializeField] private DialogueLine dialogueSystem; // Reference to your existing DialogueLine
    [SerializeField] private string[] dialogueLines;     // Lines for this specific trigger
    
    [Header("Scene Transition Settings")]
    [SerializeField] private string minigameSceneName;   // Name of minigame scene to load
    [SerializeField] private bool returnToOriginalPosition = true;
    [SerializeField] private KeyCode minigameStartKey = KeyCode.P; // Key to press to start minigame
    
    private Vector3 playerOriginalPosition;
    private string originalSceneName;
    private bool dialogueCompleted = false;
    private bool waitingForInput = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !dialogueCompleted)
        {
            // Store original scene and player position
            originalSceneName = SceneManager.GetActiveScene().name;
            playerOriginalPosition = collision.transform.position;
            
            // Start the dialogue
            dialogueSystem.lines = dialogueLines;
            dialogueSystem.gameObject.SetActive(true);
            dialogueSystem.StartDialogue();
            
            // Start checking for dialogue completion
            StartCoroutine(WaitForDialogueCompletion());
        }
    }

    private IEnumerator WaitForDialogueCompletion()
    {
        // Wait until the dialogue system is disabled (which happens when complete)
        while (dialogueSystem.gameObject.activeSelf)
        {
            yield return null;
        }
        
        // Dialogue completed, wait for P key press
        dialogueCompleted = true;
        waitingForInput = true;
        
        // Optional: Show a message indicating to press P
        Debug.Log("Press P to start the minigame");
    }

    private void Update()
    {
        if (waitingForInput && Input.GetKeyDown(minigameStartKey))
        {
            waitingForInput = false;
            SceneManager.LoadScene(minigameSceneName);
        }
    }

    // Call this from your minigame when it's completed
    public void ReturnFromMinigame()
    {
        if (returnToOriginalPosition)
        {
            // Load original scene
            SceneManager.LoadScene(originalSceneName);
            
            // Find player and return to original position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = playerOriginalPosition;
            }
        }
    }
}