using UnityEngine;





 public class Unit : MonoBehaviour
{
    public string unitName;
    public int health;
    public int maxHealth;
    public int level;
    public int damage;

    public bool TakeDamage(int dmg)
    {
        health -= dmg;

        if(health <= 0)
            return true;
        else
            return false;
    }
}

