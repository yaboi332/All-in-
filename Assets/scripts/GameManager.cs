using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private float time = 0.1f;
    [SerializeField] private bool isPlayerTurn = true;
    [SerializeField] private GameObject playerPrefab;
    public bool IsPlayerTurn => isPlayerTurn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
private void Start()
    {
       if(playerPrefab != null)
        {
           GameObject playerInstance = Instantiate(playerPrefab);
        playerInstance.name = "Player";
    }
    else 
    {
        Debug.LogError("GameManager: Player Prefab is missing! Drag your player from the Project window into the GameManager slot.");
        }
    }
public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        StartCoroutine(WaitForTurns());

    }
    private IEnumerator WaitForTurns()
    {
        yield return new WaitForSeconds(time);
        isPlayerTurn = true;
    }

   
  
}
