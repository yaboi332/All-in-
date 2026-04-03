using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Unit myUnit;
    private Unit playerUnit;

    // This connects the AI to the stats it needs to make decisions
    public void Setup(Unit self, Unit player)
    {
        myUnit = self;
        playerUnit = player;
    }

    // The "Brain" function
    public string DecideAction()
    {
        // For now, keep it simple. We can add complex logic later.
        if (myUnit.health < 20) 
        {
            return "Heal"; // Example of future logic
        }
        
        return "Attack";
    }
}