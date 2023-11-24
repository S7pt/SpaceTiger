using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
    public float Cooldown;
    public abstract void Execute(PlayerController player);
}
