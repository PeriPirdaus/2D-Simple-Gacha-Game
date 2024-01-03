using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    public WeaponGachaRate[] weaponGachaRate;
    public CharacterGachaRate[] characterGachaRate;
    [SerializeField, Range(1, 100)] private int oneTimeRate;

    //UI
    public GameObject resultParent1;
    public GameObject resultParent2;
    public GameObject itemResult;

    public void OneTimeGacha()
    {
        int rarityWeGet = 0;
        rarityWeGet = UnityEngine.Random.Range(1, 101);
        //Debug.Log($"Rarity we get: {rarityWeGet}");

        int charOrWeapon = 0;
        charOrWeapon = UnityEngine.Random.Range(1, 101);
        //Debug.Log($"Char or Weapon we get: {charOrWeapon}");

        if (Inventory.Instance.CheckIfPlayerHaveCharacterOrNot())
        {
            CharacterGacha();
        }
        else
        {
            if (charOrWeapon <= oneTimeRate)
            {
                WeaponGacha();
            }
            else
            {
                CharacterGacha();
            }
        }
    }

    public void TenTimeGacha()
    {
        for(int i = 1;i <= 8; i++)
        {
            WeaponGacha();
        }

        for(int i = 9;  i <= 10; i++)
        {
            CharacterGacha();
        }
    }

    void WeaponGacha()
    {
        int rarityWeGet = 0;
        rarityWeGet = UnityEngine.Random.Range(1, 101);
        //Debug.Log($"Rarity we get: {rarityWeGet}");

        for (int i = 0; i < weaponGachaRate.Length; i++)
        {
            if (rarityWeGet <= weaponGachaRate[i].rateLevel)
            {
                WeaponScriptableObject wso = Weapon(weaponGachaRate[i].rarityName);
                Inventory.Instance.AddWeapon(wso);
                SpawnReward(wso);

                //Debug.Log($"Should be get {wso.weaponName}");
                return;
            }
        }
    }

    void CharacterGacha()
    {
        int rarityWeGet = 0;
        rarityWeGet = UnityEngine.Random.Range(1, 101);
        //Debug.Log($"Rarity we get: {rarityWeGet}");

        for (int i = 0; i < characterGachaRate.Length; i++)
        {
            if (rarityWeGet <= characterGachaRate[i].rateLevel)
            {
                CharacterScriptableObject cso = Character(characterGachaRate[i].rarityName);
                Inventory.Instance.AddCharacter(cso);
                SpawnReward(null, cso);

                //Debug.Log($"Should be get {wso.weaponName}");
                return;
            }
        }
    }

    WeaponScriptableObject Weapon(string rarityName)
    {
        WeaponGachaRate localGachaRate = Array.Find(weaponGachaRate, x => x.rarityName == rarityName);
        WeaponScriptableObject[] reward = localGachaRate.weapons;

        int rnd = UnityEngine.Random.Range(0, reward.Length);
        return reward[rnd];
    }

    CharacterScriptableObject Character(string rarityName)
    {
        CharacterGachaRate localGachaRate = Array.Find(characterGachaRate, x => x.rarityName == rarityName);
        CharacterScriptableObject[] reward = localGachaRate.characters;

        int rnd = UnityEngine.Random.Range(0, reward.Length);
        return reward[rnd];
    }

    public void SpawnReward(WeaponScriptableObject weapon = null, CharacterScriptableObject character = null)
    {
        GameObject x = null;

        if (resultParent1.transform.childCount < 5)
        {
            x = Instantiate(itemResult, resultParent1.transform);
        }
        else
        {
            x = Instantiate(itemResult, resultParent2.transform);
        }

        ItemResult ir = x.GetComponent<ItemResult>();

        if(weapon != null)
        {
            ir.weapon = weapon;
        }
        else
        {
            ir.character = character;
        }
    }
}
