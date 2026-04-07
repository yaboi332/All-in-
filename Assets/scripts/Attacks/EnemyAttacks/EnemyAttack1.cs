using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAttack1", menuName = "Attacks/Enemy Attack 1")]
public class EnemyAttack1 : Attacks
{
    private void OnEnable()
    {
        attackName = "Enemy Attack 1";
        damage = 10;
        type = attackType.STRIKE;
        skillPointCost = 0; // Enemy attacks don't use skill points
        description = "A basic strike attack used by the enemy.";
    }

    override
    public int DealDamage(EnemyAnimations enemyAnimations)
    {   
        enemyAnimations.Attack();
       
        // Here you can add any special effects or logic specific to this attack
        return damage;
    }

   
}
