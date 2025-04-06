using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLine : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;      // Assigned by NPC script
    public float textSpeed = 0.05f;

    private int index;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // Disable on start (NPC will enable it)
        gameObject.SetActive(false);
    }

    public void StartDialogue()
    {
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        
        audioManager.PlaySFX(audioManager.dialog);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        audioManager.StopSFX(audioManager.dialog);
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                audioManager.StopSFX(audioManager.dialog);
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public GameObject player; // Drag player in Inspector

    void OnEnable()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    void OnDisable()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
