using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    Unit playerUnit;
    Unit enemyUnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BattleState state;
    void Start()
    {
        state = BattleState.START;
        setupBattle();
    }
    void setupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation.position, playerBattleStation.rotation);
        Unit playerUnit = playerGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, enemyBattleStation.rotation);
        Unit enemyUnit = enemyGO.GetComponent<Unit>();
        // Setup the battle, e.g. spawn player and enemy
       Instantiate(playerPrefab, playerBattleStation.position, playerBattleStation.rotation);
       Instantiate(enemyPrefab, enemyBattleStation.position, enemyBattleStation.rotation);
       
    }
    
    // Update is called once per frame
    
}
