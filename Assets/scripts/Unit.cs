using System.Net;
using UnityEngine;





 public class Unit : MonoBehaviour
{
    public string unitName;
    public int health;
    public int maxHealth;
    public int level;
    public int damage;
    public StatusManager statusManager;
    
    
    
    
    public virtual void Init()
{
    statusManager = GetComponent<StatusManager>();
}

    protected virtual  void Start()
    {
        /*statusManager = GetComponent<StatusManager>();
        if(statusManager == null)
        {
            Debug.LogError("No StatusManager component found on " + gameObject.name);
            statusManager = gameObject.AddComponent<StatusManager>();
        }
        */
    }
     

    public bool TakeDamage(int dmg)
    {
        health -= dmg;

        if(health <= 0)
            return true;
        else
            return false;
    }
}

