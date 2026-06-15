using UnityEngine;

[CreateAssetMenu(fileName = "Powerups", menuName = "Powerups")]
public class Powerups : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float duration;

    public string GetPowerupType()
    {
        return powerupType;
    }

    public float GetValueChange()
    {
        return valueChange;
    }

    public float GetDuration()
    {
        return duration;
    }
}
