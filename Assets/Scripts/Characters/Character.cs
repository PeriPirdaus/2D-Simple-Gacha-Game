using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public SpriteRenderer slotTanganKanan;
    public SpriteRenderer slotTanganKiri;

    //[SerializeField] private CharacterScriptableObject characterScriptableObject;
    [SerializeField] private int health;
    [SerializeField] private int defense;
    [SerializeField] private int baseAtk;
    [SerializeField] private int weaponAtk;
    public CharacterJob characterJob { private set; get; }

    public void SetupCharacterDetails(CharacterScriptableObject characterScriptableObject)
    {
        health = characterScriptableObject.healthPoint;
        defense = characterScriptableObject.defPoint;
        baseAtk = characterScriptableObject.atkPoint;

        characterJob = characterScriptableObject.characterJob;
    }

    public void EquipSingleWeapon(WeaponScriptableObject weapon)
    {
        slotTanganKiri.sprite = weapon.sprite2;

        weaponAtk = weapon.atkPoint;
        //Debug.Log($"Harusnya karakter pakai 1 senjata di sini");
    }

    public void EquipMultiWeapon(WeaponScriptableObject weapon)
    {
        slotTanganKanan.sprite = weapon.sprite1;
        slotTanganKiri.sprite = weapon.sprite2;

        weaponAtk = weapon.atkPoint;
        //Debug.Log($"Harusnya karakter pakai 2 senjata di sini");
    }
}
