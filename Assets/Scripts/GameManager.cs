using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private CharacterScriptableObject characterToEquip;
    [SerializeField] private WeaponScriptableObject weaponToEquip;
    [SerializeField] private Transform spawnPosition;

    public GameObject _player { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EquipCharacterAndWeapon(CharacterScriptableObject character, WeaponScriptableObject weapon)
    {
        characterToEquip = character;
        weaponToEquip = weapon;

        SpawnCharacterAndEquipWeapon();
    }

    [ContextMenu("DEBUG_TEST_SPAWN_CHARACTER")]
    public void SpawnCharacterAndEquipWeapon()
    {
        if(_player != null)
        {
            DestroyCharacter();
        }

        Vector3 position = new Vector3(spawnPosition.position.x, spawnPosition.position.y, 0f);
        Quaternion rotation = new Quaternion(0, 0, 0, 1);
        _player = Instantiate(characterToEquip.prefab, position, rotation);

        Character character = _player.GetComponent<Character>();
        character.SetupCharacterDetails(characterToEquip);
        //Debug.Log($"Characternya harusnya jobnya ini: {character.characterJob}");

        switch (character.characterJob)
        {
            case CharacterJob.KNIGHT:
                character.EquipSingleWeapon(weaponToEquip);
                break;
            case CharacterJob.SOLDIER:
                character.EquipMultiWeapon(weaponToEquip);
                break;
            case CharacterJob.THIEF:
                character.EquipMultiWeapon(weaponToEquip);
                break;
            case CharacterJob.ARCHER:
                character.EquipMultiWeapon(weaponToEquip);
                break;
            case CharacterJob.PRIEST:
                character.EquipSingleWeapon(weaponToEquip);
                break;
        }
    }

    void DestroyCharacter()
    {
        Destroy(_player);
    }
}