using UnityEngine;
using System.Collections;




[CreateAssetMenu(fileName = "Burn", menuName = "Status Effects/Burn")]
public class Burn : StatusEffect
{   
        
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    public override void OnTick(Unit unit, StatusEffectInstance effectInstance)
    {
        if(effectInstance.currentTurnDuration <= 0) return;

        unit.TakeDamage(damageTick * effectInstance.currentStacks);
        effectInstance.currentTurnDuration--;
        
    } 
}
