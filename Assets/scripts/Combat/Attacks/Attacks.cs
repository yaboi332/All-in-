
using UnityEngine;

abstract public class Attacks : ScriptableObject
{
    public string attackName;
    public int damage;
    public enum attackType { STRIKE, RANGED };
    public attackType type;
    public int skillPointCost;
    public string description;

    public StatusEffect[] statusEffects; // Array to hold any status effects this attack may apply

    
   

    public virtual int DealDamage(PlayerAnimations playerAnimations,EnemyAnimations enemyAnimations,StatusManager enemyStatusManager)
    {   
        int damageDealt = damage;
        foreach (StatusEffect effect in statusEffects)
        {
            if (effect != null)
            {
                enemyStatusManager.ApplyStatusEffect(effect);
                Debug.Log("Applied " + effect.name + " to the enemy!");
            }
        }
        return damageDealt;
    }

    public virtual int DealDamage(EnemyAnimations enemyAnimations)
    {   
        return damage;
    }

    public attackType GetAttackType()
    {
        return type;
    }
}
