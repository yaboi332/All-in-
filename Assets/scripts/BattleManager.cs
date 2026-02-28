using UnityEngine;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BattleState state;
    void Start()
    {
        state = BattleState.START;
        setupBattle();
    }
    void setupBattle()
    {
        // Setup the battle, e.g. spawn player and enemy
        state = BattleState.PLAYERTURN;
    }

    // Update is called once per frame
    
}
