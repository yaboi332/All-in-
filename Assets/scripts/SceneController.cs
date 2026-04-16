using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator transitionAnimator;
    public static SceneController instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IEnumerator LoadScene(string sceneName)
    {
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.0f); // Wait for the transition to complete
        SceneManager.LoadSceneAsync(sceneName);
        yield return null; // Wait for the scene to load
        transitionAnimator.SetTrigger("Start");
    }

  
}
