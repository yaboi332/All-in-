using UnityEngine;
[System.Serializable]
public class ItemInstance
{
  public Item item;

  
  public int RemainingUses; // Tracks how many uses are left for this item instance

  public void Initialize()
  {
    if (item == null)
        {
            Debug.LogError("ItemInstance has no item assigned!");
            return;
        }

    
     RemainingUses = item.MaxUses;
  } 

 
}
