using System.Collections.Generic;
using UnityEngine;

public class BattleStateManager
{
    public BattleStateManager Instance;
    public Dictionary<string,int> HealthMap  = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Multiple instances of BattleStateManager found! Destroying duplicate.");
            Destroy(this);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        if(Instance.HealthMap.ContainsKey("Player"))
        {
            Debug.LogWarning("HealthMap already contains key 'Player'. Overwriting value.");
            Instance.HealthMap["Player"] = currentHealth;
        }
        else
        {
            Instance.HealthMap.Add("Player", 100);
        }
    }

    void EndBattle(int currentHealth)
    {
        Instance.HealthMap["Player"]=currentHealth;
    }

    public void getHealth(string unitName)
    {
        if(Instance.HealthMap.ContainsKey(unitName))
        {
            int health = Instance.HealthMap[unitName];
            Debug.Log(unitName + " has " + health + " health remaining.");
        }
        else
        {
            Debug.LogWarning("HealthMap does not contain key '" + unitName + "'.");
        }
    }
}
