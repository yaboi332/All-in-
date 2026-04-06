using UnityEngine;


public class Player : Unit
{
    public int skillPoints;
    public int MaxSkillPoints;
    public PlayerAnimations playerAnimations;

    public Attacks[] attacks; // Array to hold the player's attacks

     // Example of assigning an attack to the array

    void Start()
    {
         // Example of assigning an attack to the array
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    public int weaponAttack()
    {   
        if (skillPoints >= attacks[0].skillPointCost)
         {
            playerAnimations.Attack();
        // Example: weapon attack costs 1 skill point
            skillPoints -= attacks[0].skillPointCost;
            int damageDealt = attacks[0].DealDamage(playerAnimations); // Assuming playerUnit is accessible
            Debug.Log ("Player used " + attacks[0].attackName + " and dealt " + damageDealt + " damage!");
            return damageDealt;
        }
        else
        {
            Debug.Log("Not enough skill points!");
            return 0; // No damage dealt if not enough skill points
        }
    
    }


    public int skillAttack()
    {
        if (skillPoints >= 2)
        {  
             playerAnimations.Attack();
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




