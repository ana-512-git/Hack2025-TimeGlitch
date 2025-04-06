using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
    {
        public Texture2D imageToUse;
        public GameManager puzzleManager;

        private bool hasTriggered = false;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!hasTriggered && other.CompareTag("Player"))
            {
                hasTriggered = true;
               // puzzleManager.StartGame(imageToUse);
            }
        }
    }
