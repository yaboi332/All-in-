using UnityEngine;
using System.Collections;
abstract public class StatusEffect : ScriptableObject
{
    public enum EffectType {Burn,Poison};
    public EffectType type;
    public string effectName;
    public string description;
    public int maxTurnDuration;

    public int damageTick;
    public int maxStacks;

    
    
   public virtual void OnApply(Unit unit, StatusEffectInstance effectInstance){}

    public abstract void OnTick(Unit unit, StatusEffectInstance effectInstance);

    // Update is called once per frame
}
