using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsData", menuName = "WeaponsData")]
public class WeaponScriptableObject : ScriptableObject
{
    public string weaponName;
    public Sprite weaponThumbnail;
    public int atkPoint;
    public SpecialEffect specialEffect = SpecialEffect.NONE;
    public CharacterJob suitableFor;
    public Sprite sprite1;
    public Sprite sprite2;

    public enum SpecialEffect
    {
        NONE,
        BLEED,
        HOLY
    }
}
