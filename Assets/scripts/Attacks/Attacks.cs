using UnityEngine;

abstract public class Attacks : ScriptableObject
{
    public string attackName;
    public int damage;
    public char type; // 's' for strike, 'r' for ranged
    public int skillPointCost;
    public string description;

    
    public virtual int DealDamage(PlayerAnimations playerAnimations)
    {   

        return damage;
    }
}
