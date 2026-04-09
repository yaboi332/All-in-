using UnityEngine;
using System.Collections.Generic;

public class StatusManager : MonoBehaviour
{

List<StatusEffectInstance> activeStatusEffects = new List<StatusEffectInstance>();// Array to hold active status effects on the unit
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    public void ApplyStatusEffect(StatusEffect newEffect)
    {   
        foreach (var instance in activeStatusEffects)
        {
            if (instance.effect != null && instance.effect.type == newEffect.type)
            {
                instance.currentTurnDuration = instance.effect.maxTurnDuration; // Reset duration if the same effect is applied again
                if (instance.currentStacks < instance.effect.maxStacks)
                {
                    instance.currentStacks++;
                    Debug.Log("Increased stacks of " + instance.effect.effectName + " to " + instance.currentStacks);
                }
                else
                {
                    Debug.Log(instance.effect.effectName + " is already at maximum stacks!");
                }
                return; // Exit the method after handling the existing effect
            }
        }
        StatusEffectInstance newEffectInstance = new StatusEffectInstance();
        newEffectInstance.effect = newEffect;
        newEffectInstance.Initialize(); // Initialize the new effect's duration and stacks
        activeStatusEffects.Add(newEffectInstance);
        Debug.Log("Applied new status effect: " + newEffect.effectName);
    }

    public void tickStatusEffects(Unit unit)
    {
        foreach(var instance in activeStatusEffects)
        {
            if(instance != null)
            {   
                if(instance.currentTurnDuration > 0)
                instance.effect.OnTick(unit, instance);
            }
        }
    }



    public void turnStartStatusEffects(Unit unit)
{
    for (int i = activeStatusEffects.Count - 1; i >= 0; i--)
    {
        if (activeStatusEffects[i].currentTurnDuration <= 0)
        {
            activeStatusEffects.RemoveAt(i);
        }
    }
}
    /*public void removeStatusEffect(int index)
    {
        activeStatusEffects[index].currentStacks=0;
        activeStatusEffects[index] = null;
        for(int i = index; i < statusNumber-1; i++)
        {
            activeStatusEffects[i] = activeStatusEffects[i+1];
        }
        activeStatusEffects[statusNumber-1] = null;
        statusNumber--;
    } */
    
    public void clearStatusEffects()
    {
        activeStatusEffects.Clear();
    }



    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
