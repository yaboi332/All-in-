
using UnityEngine;

abstract public class Attacks : ScriptableObject
{
    public string attackName;
    public int damage;
    public enum attackType { STRIKE, RANGED };
    public attackType type;
    public int skillPointCost;
    public string description;

    
    public virtual int DealDamage(PlayerAnimations playerAnimations,EnemyAnimations enemyAnimations)
    {   

        return damage;
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
