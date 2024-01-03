using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharData", menuName = "CharData")]
public class CharacterScriptableObject : ScriptableObject
{
    public string charName;
    public Sprite charSprite;
    public GameObject prefab;
    public GameObject thumbnail;
    public int atkPoint;
    public int healthPoint;
    public int defPoint;
    public CharacterJob characterJob;
}

public enum CharacterJob
{
    KNIGHT,
    SOLDIER,
    ARCHER,
    PRIEST,
    THIEF
}
