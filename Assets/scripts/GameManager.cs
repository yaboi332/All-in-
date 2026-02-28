using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private float time = 0.1f;
    [SerializeField] private bool isPlayerTurn = true;
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
        // Initialize game state or load resources here
        Instantiate(Resources.Load<GameObject>("Prefabs/Player")).name = "Player";
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
