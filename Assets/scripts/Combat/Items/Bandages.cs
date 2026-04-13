using UnityEngine;
[CreateAssetMenu(fileName = "Bandages", menuName = "Items/Bandages")]
 public class Bandages : Item
{
    public int healAmount;

    public override void UseItemSelf(Unit unit, ItemInstance itemInstance)
    {
        if (itemInstance != null)
        {
            unit.health+= healAmount;
            Debug.Log("Used " + itemName + " on self, healing for " + healAmount + " health!");

            itemInstance.RemainingUses--;
        }
    }
}