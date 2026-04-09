using System.Collections;
using System.Diagnostics;
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
    Player playerUnit;
    
    public PlayerAnimations playerAnimations;
    public EnemyAnimations enemyAnimations;

    Enemy enemyUnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BattleState state;

    public BattleHUD battleHUD;
    private EnemyAI activeEnemyAI;

    public PopUpManager popUpManager;
    public ParrySelectWindow parrySelectWindow;
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
    enemyUnit = enemyGO.GetComponent<Enemy>();
    enemyAnimations = enemyGO.GetComponent<EnemyAnimations>();
// 3. Get the AI component (NEW)
        activeEnemyAI = enemyGO.GetComponent<EnemyAI>();

        // 4. Tell the AI who it is and who the player is
        if(activeEnemyAI != null)
        {
            activeEnemyAI.Setup(enemyUnit, playerUnit);
        }
    battleHUD.SetHUD(playerUnit,enemyUnit);

    
    playerTurn(); 
}       

   

    public void onWeaponButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        
        if(!playerUnit.skillPointCheck(playerUnit.attacks[0].skillPointCost))
        {   
            popUpManager.PopUp("Not enough skill points!");
            UnityEngine.Debug.Log("Not enough skill points!");
            return;
        }

       popUpManager.PopUp("Player used " + playerUnit.attacks[0].attackName + " and dealt " + playerUnit.attacks[0].damage + " damage!"); 
       bool isEnemyDead=enemyUnit.TakeDamage(playerUnit.weaponAttack(enemyAnimations));
       battleHUD.SetSP(playerUnit);
       battleHUD.SetHp(playerUnit.health,enemyUnit.health);

        //Check if the enemy is dead
        if(isEnemyDead)
        {
            // End the battle
            enemyDefeated();
        }
        else
        {
            state = BattleState.PLAYERTURN;
                
        }
        
    }

    public void onSkillButton()
    {
        
         popUpManager.PopUp("Player used " + playerUnit.attacks[0].attackName + " and dealt " + playerUnit.attacks[0].damage * 2 + " damage!");
        if (state != BattleState.PLAYERTURN)
            return;
        if(!playerUnit.skillPointCheck(2)) // Assuming skill attack costs 2 skill points
        {   
            popUpManager.PopUp("Not enough skill points!");
            UnityEngine.Debug.Log("Not enough skill points!");
            return;
        }    
        
    
       bool isEnemyDead=enemyUnit.TakeDamage(playerUnit.skillAttack(enemyAnimations));
       battleHUD.SetSP(playerUnit);
       battleHUD.SetHp(playerUnit.health,enemyUnit.health);

        //Check if the enemy is dead
        if(isEnemyDead)
        {
            // End the battle
            enemyDefeated();
        }
        else
        {
            state = BattleState.PLAYERTURN;
               
        }
        
    }

    public void onParryButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        if(!playerUnit.skillPointCheck(1)) // Assuming parry costs 1 skill point
        {
            popUpManager.PopUp("Not enough skill points to parry!");
            UnityEngine.Debug.Log("Not enough skill points to parry!");
            return;
        }
        parrySelectWindow.PopUp();
        state = BattleState.PLAYERTURN;
    }

    public void onStrikeParryButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        popUpManager.PopUp("Player is preparing to parry!");
        playerUnit.strikeParry();
        state = BattleState.PLAYERTURN;
        parrySelectWindow.HidePopUp();
        battleHUD.SetSP(playerUnit);
    }


    public void onRangedParryButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        popUpManager.PopUp("Player is preparing to parry!");
        playerUnit.rangedParry();
        state = BattleState.PLAYERTURN;
        parrySelectWindow.HidePopUp();
        battleHUD.SetSP(playerUnit);
    }

    public void onCloseParrySelectButton()
    {
        parrySelectWindow.HidePopUp();
    }
     public void playerTurn()
    {
       state = BattleState.PLAYERTURN;
        playerUnit.refreshPlayerTurn();
        popUpManager.PopUp("Player's Turn! Skill Points: " + playerUnit.skillPoints);
        battleHUD.SetSP(playerUnit);
    
    }

    private void enemyAttack()
    {
        // Damage the player
        bool isPlayerDead;
        if(playerUnit.currentState == Player.playerState.STRIKE_PARRYING || playerUnit.currentState == Player.playerState.RANGED_PARRYING)
        {
            if (playerUnit.ParryCheck(enemyUnit.attacks[0]))
        {   enemyUnit.attacks[0].DealDamage(enemyAnimations);
            double totalDamage = enemyUnit.attacks[0].damage * playerUnit.parryMultiplier;
            int finalDamage = Mathf.RoundToInt((float)totalDamage);
            popUpManager.PopUp("Player parried the attack and dealt " + finalDamage + " damage!",3f);
            UnityEngine.Debug.Log("Player parried the attack and dealt " + finalDamage + " damage!");
            isPlayerDead = enemyUnit.TakeDamage(finalDamage);
            if(isPlayerDead)
        {
            // End the battle
            enemyDefeated();
            return;
        }
            
        }
        else
        {
             enemyUnit.attacks[0].DealDamage(enemyAnimations);
            double totalDamage = enemyUnit.attacks[0].damage * playerUnit.parryMultiplier;
            int finalDamage = Mathf.RoundToInt((float)totalDamage);
                popUpManager.PopUp("Player failed to parry and took " + finalDamage + " damage!",3f);
                UnityEngine.Debug.Log("Player failed to parry and took " + finalDamage + " damage!");
            isPlayerDead = playerUnit.TakeDamage(finalDamage);
             if(isPlayerDead)
        {
            // End the battle
            state = BattleState.LOST;
            return;
        }
        }
        
            
        }

        else
        {
             popUpManager.PopUp("Enemy used " + enemyUnit.attacks[0].attackName + " and dealt " + enemyUnit.attacks[0].damage + " damage!");
           isPlayerDead=playerUnit.TakeDamage(enemyUnit.attacks[0].DealDamage(enemyAnimations));
             if(isPlayerDead)
        {
            // End the battle
            state = BattleState.LOST;
            return;
        } 
        }
       
        

        playerUnit.parryMultiplier = 0.0; // Reset parry multiplier after the attack
        
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
            
        }

                
        
    }
    public void enemyTurn()
    {   popUpManager.PopUp("Enemy's Turn!");
        if (state != BattleState.ENEMYTURN)
            return;
           StartCoroutine(EnemyActionDelay());
           StartCoroutine(TurnDelay());
           
           
    }
    IEnumerator EnemyActionDelay()
{
    yield return new WaitForSeconds(1.5f); // Give the player time to breathe
    enemyAttack();
}

    IEnumerator TurnDelay()
{
    yield return new WaitForSeconds(5f);
    playerTurn(); // Give the player time to breathe
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

public void enemyDefeated()
{
    state = BattleState.WON;
    enemyAnimations.Dead();
    popUpManager.PopUp("Enemy Defeated! You Win!", 5f);
}
}


