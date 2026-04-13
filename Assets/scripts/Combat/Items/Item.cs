using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    public string description; 

    public int MaxUses; // Maximum number of times the item can be used

    public enum ItemType { Heal,Buff, Debuff, Damage}

    public ItemType itemType;
 
    
    public virtual void UseItemSelf(Unit unit, ItemInstance itemInstance){}

    public virtual void UseItemTarget(Unit unit, Unit target, ItemInstance itemInstance){}

    public ItemType GetTypeOfItem()
    {
        return itemType;
    }
}
