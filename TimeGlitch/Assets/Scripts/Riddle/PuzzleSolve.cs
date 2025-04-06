using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;


public class PuzzleSolve : MonoBehaviour
{
    public TMPro.TMP_InputField input;

    private void Start() {
        input.onEndEdit.AddListener(SubmitText);
    }

    private void SubmitText(string userInput) {
        userInput = userInput.Trim();

        if(userInput.All(char.IsLetter))
            if(userInput.ToLower() == "time") {
                StartCoroutine(ControlManager.LoadSceneWithDelay(1.5f));
                return;
            }

        input.text = "";
        input.ActivateInputField();
    }
}
