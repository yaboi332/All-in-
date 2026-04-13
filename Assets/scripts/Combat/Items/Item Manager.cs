using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    
    public List<ItemInstance> ActiveItems = new List<ItemInstance>();
    
    public ItemDatabase database; // Reference to the item database ScriptableObject

    public List<Item> allItems = new List<Item>();

    public void awake()
    {
        allItems = new List<Item>(database.items);
    }

    public void AddItem(Item newItem)
    {   
        foreach (var instance in ActiveItems)
        {
            if (instance.item == newItem)
            {
                instance.RemainingUses+=newItem.MaxUses; // Increase remaining uses if the same item is added again
                Debug.Log("Increased uses of " + newItem.itemName + " to " + instance.RemainingUses);
                return;
            }
        }
        ItemInstance newItemInstance = initializeItem(newItem);
        ActiveItems.Add(newItemInstance);
        Debug.Log("Added new item: " + newItem.itemName);
    }

    public void UseItem(Unit unit, ItemInstance itemInstance, Unit target = null)
    {
        if (itemInstance!=null && itemInstance.RemainingUses > 0)
        {
            if(itemInstance.item.GetTypeOfItem() == Item.ItemType.Heal || itemInstance.item.GetTypeOfItem() == Item.ItemType.Buff)
            { // If the item is a Heal or Buff type, use it on self
                itemInstance.item.UseItemSelf(unit, itemInstance);
            }
            else
            { // If the item is a Debuff or Damage type, use it on the target
                itemInstance.item.UseItemTarget(unit, target, itemInstance);
            }
            itemInstance.RemainingUses--;
            Debug.Log("Used item: " + itemInstance.item.itemName + ". Remaining uses: " + itemInstance.RemainingUses);
            if (itemInstance.RemainingUses <= 0)
            {
                ActiveItems.Remove(itemInstance);
                Debug.Log("Item " + itemInstance.item.itemName + " has been fully used and removed from inventory.");
            }
        }
    }

    public ItemInstance initializeItem(Item NewItem)
    {
        ItemInstance newItemInstance = new ItemInstance();
        newItemInstance.item = NewItem;
        newItemInstance.Initialize(); // Initialize the new item's remaining uses
        return newItemInstance;
          
    }
}
