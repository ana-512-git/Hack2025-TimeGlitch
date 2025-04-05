using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlManager : MonoBehaviour
{
    private CableDrag[] cables;
    private bool sceneLoaded = false;
    
    void Start() {
        cables = Object.FindObjectsOfType<CableDrag>();
    }

    void Update() {
        if(sceneLoaded) return;

        sceneLoaded = true;
        foreach(CableDrag cable in cables) 
            if(!cable.isFinish()) {
                sceneLoaded = false;
                break;
            }
        
        if(sceneLoaded) StartCoroutine(LoadSceneWithDelay(1.5f));
    }

    public static IEnumerator LoadSceneWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("SampleScene");
    }
}
