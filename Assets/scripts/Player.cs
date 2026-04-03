using UnityEngine;


public class Player : Unit
{
    public int skillPoints;
    public int MaxSkillPoints;
    public PlayerAnimations playerAnimations;

    void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

public int weaponAttack()
{   playerAnimations.Attack();
     skillPoints -= 1; // Example: weapon attack costs 1 skill point
    skillPoints -= 1;
    int damageDealt = damage; // Assuming playerUnit is accessible
    
    return damageDealt;
}


public int skillAttack()
{
    if (skillPoints >= 2)
    {   playerAnimations.Attack();
        skillPoints -= 2; // Example: skill attack costs 2 skill points
        int damageDealt = damage * 2; // Example: skill attack does double damage
        return damageDealt;
    }
    else
    {
        Debug.Log("Not enough skill points!");
        return 0; // No damage dealt if not enough skill points
    }
}






}




