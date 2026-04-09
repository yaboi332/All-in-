using UnityEngine;

[CreateAssetMenu(fileName = "Ignite", menuName = "Attacks/Ignite")]
public class Ignite : Attacks
{
    


    override
    public int DealDamage(PlayerAnimations playerAnimations,EnemyAnimations enemyAnimations,StatusManager enemyStatusManager)
    {
        
        playerAnimations.Attack(enemyAnimations);
        foreach (StatusEffect effect in statusEffects)
        {
            if (effect != null)
            {
                enemyStatusManager.ApplyStatusEffect(effect);
                Debug.Log("Applied " + effect.effectName + " to the enemy!");
            }
        }
    
        Debug.Log("Ingnite dealt " + damage + " damage!");
        return damage;
    }
}