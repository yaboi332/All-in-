using UnityEngine;


public class Player : Unit
{
    public int skillPoints;
    public int MaxSkillPoints;
    
    public PlayerAnimations playerAnimations;
    public enum playerState { STRIKE_PARRYING,RANGED_PARRYING, IDLE };
    public playerState currentState;
    public double parryMultiplier;

    public Attacks[] attacks; // Array to hold the player's attacks
    public ItemInstance[] items; // Array to hold the player's items
    /*
    private ItemManager itemManager; // Instance of the ItemManager
    
    public override void Init()
    {
        base.Init();
        itemManager = GetComponent<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("No ItemManager component found on " + gameObject.name);
            itemManager = gameObject.AddComponent<ItemManager>();
        }
    }
    */

     // Example of assigning an attack to the array

    protected override void Start()
    {
        base.Start();
         // Example of assigning an attack to the array
        playerAnimations = GetComponent<PlayerAnimations>();
       // statusManager = GetComponent<StatusManager>();
         // Initialize the array to hold two attacks
        currentState = playerState.IDLE;
        parryMultiplier = 0.0; // Example parry multiplier


        
    }

    public void refreshPlayerTurn()
    {
        skillPoints = MaxSkillPoints;
        currentState = playerState.IDLE;
        parryMultiplier = 0.0; // Reset parry multiplier at the start of the turn
    }

    public int weaponAttack(EnemyAnimations enemyAnimations,StatusManager enemyStatusManager)
    {   
        if (skillPoints >= attacks[0].skillPointCost)
         {
            
        // Example: weapon attack costs 1 skill point
            skillPoints -= attacks[0].skillPointCost;
            int damageDealt = attacks[0].DealDamage(playerAnimations,enemyAnimations,enemyStatusManager); // Assuming playerUnit is accessible
            Debug.Log ("Player used " + attacks[0].attackName + " and dealt " + damageDealt + " damage!");
            return damageDealt;
        }
        else
        {
            Debug.Log("Not enough skill points!");
            return 0; // No damage dealt if not enough skill points
        }
    
    }


    public int skillAttack(EnemyAnimations enemyAnimations, StatusManager enemyStatusManager)
    {
        if (skillPoints >= attacks[1].skillPointCost)
         {
            
        // Example: weapon attack costs 1 skill point
            skillPoints -= attacks[1].skillPointCost;
            int damageDealt = attacks[1].DealDamage(playerAnimations,enemyAnimations,enemyStatusManager); // Assuming playerUnit is accessible
            Debug.Log ("Player used " + attacks[1].attackName + "dealt " + damageDealt + " damage!");
            return damageDealt;
        }
        else
        {
            Debug.Log("Not enough skill points!");
            return 0; // No damage dealt if not enough skill points
        }
    }


    public void UseItem(ItemInstance itemInstance,PopUpManager popUpManager, Unit enemyUnit = null)
    {
        if (itemInstance!=null && itemInstance.RemainingUses > 0)
        {
            if(itemInstance.item.GetTypeOfItem() == Item.ItemType.Heal || itemInstance.item.GetTypeOfItem() == Item.ItemType.Buff)
            { // If the item is a Heal or Buff type, use it on self
                itemInstance.item.UseItemSelf(this, itemInstance);
                popUpManager.PopUp("Used " + itemInstance.item.itemName +". "+itemInstance.RemainingUses+" uses remaining.", 2.0f);
             }
             else
            {
                itemInstance.item.UseItemTarget(this, enemyUnit, itemInstance);
            }
        }
        else
        {
            Debug.Log("Item cannot be used. Either it's null or has no remaining uses.");
            popUpManager.PopUp("Cannot use " + itemInstance.item.itemName + ". No remaining uses!", 2.0f);
        }
    }

    public void strikeParry()
    {
        currentState= playerState.STRIKE_PARRYING;
        
        parryMultiplier=1.0 + (0.1 * skillPoints); // Example: parry multiplier increases with skill points
        skillPoints = 0;
        Debug.Log("PREPARE TO PARRY A STRIKE ATTACK!");
    }

      public void rangedParry()
    {
        currentState= playerState.RANGED_PARRYING;
        
        parryMultiplier=1.0 + (0.1 * skillPoints); // Example: parry multiplier increases with skill points
        skillPoints = 0;
        Debug.Log("PREPARE TO PARRY A RANGED ATTACK!");
    }



    public bool ParryCheck(Attacks incomingAttack)
    {
        
         if(incomingAttack.GetAttackType() == Attacks.attackType.STRIKE && currentState == playerState.STRIKE_PARRYING)
     {      
        return true;
        
        }
        else if(incomingAttack.GetAttackType() == Attacks.attackType.RANGED && currentState == playerState.RANGED_PARRYING)
        {
            return true;
        }
   
     else
     {  
        return false;
        }
    }


    public bool skillPointCheck(int cost)
    {
        return skillPoints >= cost;
    }




}




