using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;


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
                SceneManager.LoadScene("MainScene_Coffin");
                return;
            }

        input.text = "";
        input.ActivateInputField();
    }
}
