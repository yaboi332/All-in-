using UnityEngine;

public class TitleScreenScript: MonoBehaviour
{
    

    public void OnStartButton()
    {    Debug.Log("Start button clicked! Loading Battle Scene...");
        StartCoroutine(SceneController.instance.LoadScene("Battle Scene"));
       
    }
}
