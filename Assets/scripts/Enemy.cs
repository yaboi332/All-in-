using UnityEngine;

public class Enemy : Unit
{
    
    //public EnemyAnimations enemyAnimations;
    public Attacks[] attacks; // Array to hold the enemy's attacks
    

// Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        //enemyAnimations = GetComponent<EnemyAnimations>();
       // statusmanger = GetComponent<StatusManager>();
        
    }


     public int attack(EnemyAnimations enemyAnimations)
    {   
    
            if (attacks.Length == 0)
            {
                Debug.LogWarning("Enemy has no attacks assigned!");
                return 0; // No damage dealt if there are no attacks
            }
        int damageDealt = attacks[0].DealDamage(enemyAnimations); // Assuming enemyUnit is accessible
        Debug.Log ("Enemy used " + attacks[0].attackName + " and dealt " + damageDealt + " damage!");
        return damageDealt;
    }
     
     // Example of assigning an attack to the array
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
