using UnityEngine;

[System.Serializable]
public class WeaponGachaRate
{
    public string rarityName;
    [Range(0, 100)]
    public int rateLevel;
    public WeaponScriptableObject[] weapons;
}
