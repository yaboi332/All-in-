using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAttack1", menuName = "Attacks/Enemy Attack 1")]
public class EnemyAttack1 : Attacks
{
    private void OnEnable()
    {
        attackName = "Enemy Attack 1";
    
        type = attackType.STRIKE;
        skillPointCost = 0; // Enemy attacks don't use skill points
        description = "A basic strike attack used by the enemy.";
    }

    override
    public int DealDamage(EnemyAnimations enemyAnimations)
    {   
        int randomValue = Random.Range(0, 2); // Random value between 0 and 1
        if (randomValue == 0)
        {
            type=attackType.STRIKE;
        }

        else
        {
           type=attackType.RANGED; 
        }

        enemyAnimations.Attack();
       
        // Here you can add any special effects or logic specific to this attack
        return damage;
    }

   
}
