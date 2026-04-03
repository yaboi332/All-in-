using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    Player playerUnit;
    
    public PlayerAnimations playerAnimations;
    public EnemyAnimations enemyAnimations;

    Unit enemyUnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BattleState state;

    public BattleHUD battleHUD;
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
    playerUnit = playerGO.GetComponent<Player>();
    playerAnimations = playerGO.GetComponent<PlayerAnimations>();
    // Spawn Enemy and make them a child of the station
    GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
    // Reset position to (0,0,0) relative to the station
    enemyGO.transform.localPosition = Vector3.zero;
    enemyUnit = enemyGO.GetComponent<Unit>();
    enemyAnimations = enemyGO.GetComponent<EnemyAnimations>();

    battleHUD.SetHUD(playerUnit,enemyUnit);

    state = BattleState.PLAYERTURN;
    playerTurn(); 
}       

    private void playerWeaponAttack()
    {
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
            state = BattleState.ENEMYTURN;
                enemyTurn();
        }
    }
   

    public void onWeaponButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
       bool isEnemyDead=enemyUnit.TakeDamage(playerUnit.weaponAttack());
       battleHUD.SetHp(playerUnit.health,enemyUnit.health);

        //Check if the enemy is dead
        if(isEnemyDead)
        {
            // End the battle
            state = BattleState.WON;
        }
        else
        {
            state = BattleState.ENEMYTURN;
                enemyTurn();
        }
        
    }

    public void onSkillButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
       bool isEnemyDead=enemyUnit.TakeDamage(playerUnit.skillAttack());
       battleHUD.SetHp(playerUnit.health,enemyUnit.health);

        //Check if the enemy is dead
        if(isEnemyDead)
        {
            // End the battle
            state = BattleState.WON;
        }
        else
        {
            state = BattleState.ENEMYTURN;
                enemyTurn();
        }
        
    }

     public void playerTurn()
    {
        playerUnit.skillPoints = playerUnit.MaxSkillPoints;

    
    
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
            state = BattleState.PLAYERTURN;
                playerTurn();
        }
    }
    public void enemyTurn()
    {
        if (state != BattleState.ENEMYTURN)
            return;
            enemyAttack();
    }

}
