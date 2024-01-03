using UnityEngine;

[System.Serializable]
public class CharacterGachaRate
{
    public string rarityName;
    [Range(0, 100)]
    public int rateLevel;
    public CharacterScriptableObject[] characters;
}
