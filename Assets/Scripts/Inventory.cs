using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static  Inventory Instance;
    [SerializeField] private int maxWeaponsHold;
    [SerializeField] List<WeaponScriptableObject> weapons;
    [SerializeField] List<CharacterScriptableObject> characters;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddWeapon(WeaponScriptableObject weapon)
    {
        if (weapons.Contains(weapon))
        {
            weapons.Remove(weapon);
        }

        if (weapons.Count == maxWeaponsHold)
        {
            weapons.Remove(weapons[0]);
        }

        weapons.Add(weapon);
    }

    public void AddCharacter(CharacterScriptableObject character)
    {

        if (characters.Contains(character))
        {
            return;
        }
        else if(characters.Count > 3)
        {
            characters.Remove(characters[0]);
            characters.Add(character);
        }
        else
        {
            characters.Add(character);
            //Debug.Log("Hore karakter baru!");
        }
    }

    public bool CheckIfPlayerHaveCharacterOrNot()
    {
        if(characters.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<WeaponScriptableObject> GetWeaponList()
    {
        List<WeaponScriptableObject> currentList = weapons;

        return currentList;
    }

    public List<CharacterScriptableObject> GetCharacterList()
    {
        List<CharacterScriptableObject> currentList = characters;

        return currentList;
    }
}
