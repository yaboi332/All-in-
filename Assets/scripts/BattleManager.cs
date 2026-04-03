using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, BUSY, WON, LOST }
public class BattleManager : MonoBehaviour
{
    public int maxActionsPerTurn = 2;
    private int currentActionsLeft;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    Unit playerUnit;
    
    public PlayerAnimations playerAnimations;
    public EnemyAnimations enemyAnimations;

    Unit enemyUnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BattleState state;

    public BattleHUD battleHUD;
    private EnemyAI activeEnemyAI;
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
    playerAnimations = playerGO.GetComponent<PlayerAnimations>();
    // Spawn Enemy and make them a child of the station
    GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
    // Reset position to (0,0,0) relative to the station
    enemyGO.transform.localPosition = Vector3.zero;
    enemyUnit = enemyGO.GetComponent<Unit>();
    enemyAnimations = enemyGO.GetComponent<EnemyAnimations>();
// 3. Get the AI component (NEW)
        activeEnemyAI = enemyGO.GetComponent<EnemyAI>();

        // 4. Tell the AI who it is and who the player is
        if(activeEnemyAI != null)
        {
            activeEnemyAI.Setup(enemyUnit, playerUnit);
        }
    battleHUD.SetHUD(playerUnit,enemyUnit);

    state = BattleState.PLAYERTURN;
    playerTurn(); 
}       

    private void playerWeaponAttack()
    {
        if (currentActionsLeft <= 0) return;
        state = BattleState.BUSY;
        // Damage the enemy
        playerAnimations.Attack();
        bool isEnemyDead=enemyUnit.TakeDamage(playerUnit.damage);
        battleHUD.SetHp(playerUnit.health,enemyUnit.health);

        //Check if the enemy is dead
        if(isEnemyDead)
        {
            // End the battle
            state = BattleState.WON;
        }
        else
        {
           currentActionsLeft--;
        state = BattleState.PLAYERTURN;
        }
    }
   

    public void onWeaponButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        playerWeaponAttack();
        
    }

     public void playerTurn()
    {
       state = BattleState.PLAYERTURN;
    currentActionsLeft = maxActionsPerTurn; // Reset actions to 3 (or whatever you set)
    Debug.Log("Player Turn Started. Actions: " + currentActionsLeft); 
    
    }

    private void enemyAttack()
    {
        // Damage the player
        enemyAnimations.Attack();
        bool isPlayerDead=playerUnit.TakeDamage(enemyUnit.damage);
        battleHUD.SetHp(playerUnit.health,enemyUnit.health);

        //Check if the enemy is dead
        if(isPlayerDead)
        {
            // End the battle
            state = BattleState.LOST;
        }
        else
        {
            playerTurn(); // Go back to player's turn
                
        }
    }
    public void enemyTurn()
    {
        if (state != BattleState.ENEMYTURN)
            return;
           StartCoroutine(EnemyActionDelay());
    }
    IEnumerator EnemyActionDelay()
{
    yield return new WaitForSeconds(1.5f); // Give the player time to breathe
    enemyAttack();
}
public void OnEndTurnButton()
{
    // Only allow ending the turn if the player is actually allowed to move
    if (state == BattleState.PLAYERTURN)
    {
        state = BattleState.ENEMYTURN;
        enemyTurn();
    }
}

}
