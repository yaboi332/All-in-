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
    // Spawn Player and make them a child of the station
    GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
    // Reset position to (0,0,0) relative to the station
    playerGO.transform.localPosition = Vector3.zero;
    playerUnit = playerGO.GetComponent<Unit>();

    // Spawn Enemy and make them a child of the station
    GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
    // Reset position to (0,0,0) relative to the station
    enemyGO.transform.localPosition = Vector3.zero;
    enemyUnit = enemyGO.GetComponent<Unit>();
}
}
