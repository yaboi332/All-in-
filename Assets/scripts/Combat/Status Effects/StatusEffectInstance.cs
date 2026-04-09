using UnityEngine;

[System.Serializable]
public class StatusEffectInstance
{
    public StatusEffect effect;

    public int currentTurnDuration;
    public int currentStacks;

    public void Initialize()
{
    if (effect == null)
    {
        Debug.LogError("StatusEffectInstance has no effect assigned!");
        return;
    }

    currentTurnDuration = effect.maxTurnDuration;
    currentStacks = 1;
}

}
