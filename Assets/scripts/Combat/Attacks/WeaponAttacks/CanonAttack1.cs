using UnityEngine;

[CreateAssetMenu(fileName = "CanonAttack1", menuName = "Attacks/Canon Attack 1")]
public class CanonAttack1 : Attacks
{
    private void OnEnable()
    {
        attackName = "Canon Attack 1";
        type = attackType.RANGED;
        skillPointCost = 1;
        description = "A ranged cannon blast attack. 50% chance to hit twice.";
    }


    override
    public int DealDamage(PlayerAnimations playerAnimations,EnemyAnimations enemyAnimations,StatusManager enemyStatusManager)
    {
        int randomValue = Random.Range(0, 101); // Random value between 0 and 100
        
        // Here you can add any special effects or logic specific to this attack
        /*
        if (randomValue < 50)
        {   playerAnimations.Attack(enemyAnimations);
           
            playerAnimations.Attack(enemyAnimations);
            
            Debug.Log("Canon Attack 1 hit twice!");
            return damage * 2;
        }
        */
        playerAnimations.Attack(enemyAnimations);
    
        Debug.Log("Canon Attack 1 hit once!");
        return damage;
    }
}