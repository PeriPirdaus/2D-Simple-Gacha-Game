using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public NameScript nameScript;
    public CanvasMain canvasMain;

    // Weapon UI Elements
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterAttack;
    [SerializeField] private TextMeshProUGUI characterHP;
    [SerializeField] private TextMeshProUGUI characterDefense;

    // Character UI Elements
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI weaponAttack;
    [SerializeField] private TextMeshProUGUI weaponEffect;

    // Image/Sprite Container
    [SerializeField] private Transform characterPrefabContainer;
    [SerializeField] private Image weaponSpriteContainer;

    // Character & Weapon UI Item Container
    [SerializeField] private Transform characterItemContainer;
    [SerializeField] private Transform weaponItemContainer1;
    [SerializeField] private Transform weaponItemContainer2;

    [SerializeField] private GameObject itemInventoryPrefab;

    CharacterScriptableObject characterToEquip;
    WeaponScriptableObject weaponToEquip;

    public static InventoryMenu instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        // Clear Character details
        ClearCharacterDetails();

        // Clear Weapon details
        ClearWeaponDetails();

        // Load Character from Inventory first
        LoadCharacterFromInventory();
    }

    void ClearCharacterDetails()
    {
        foreach (Transform c in characterPrefabContainer.transform)
        {
            Destroy(c.gameObject);
        }

        characterName.text = $"(Unknown)";
        characterAttack.text = $"ATK: ---";
        characterHP.text = $"HP: ---";
        characterDefense.text = $"DEF: ---";
    }

    void ClearWeaponDetails()
    {
        weaponToEquip = null;
        weaponSpriteContainer.sprite = null;

        weaponName.text = $"(Unknown)";
        weaponAttack.text = $"ATK: ---";
        weaponEffect.text = $"ATK: ---";
    }

    void LoadCharacterFromInventory()
    {
        List<CharacterScriptableObject> characterList;

        try
        {
            characterList = Inventory.Instance.GetCharacterList();

            foreach (CharacterScriptableObject character in characterList)
            {
                GameObject go = Instantiate(itemInventoryPrefab, characterItemContainer);
                ItemInventory itemInventory = go.GetComponent<ItemInventory>();

                itemInventory.character = character;
            }
        }
        catch (Exception e)
        {
            Debug.Log($"List character keliatannya masih 0 njirr, detail\n{e}");
        }
    }

    IEnumerator CR_LoadWeaponFromInventory(CharacterJob type)
    {
        ClearWeaponList();
        yield return new WaitForSeconds(0.25f);
        List<WeaponScriptableObject> weaponList;

        try
        {
            weaponList = Inventory.Instance.GetWeaponList();

            foreach (WeaponScriptableObject weapon in weaponList)
            {
                if (weapon.suitableFor == type)
                {
                    GameObject go;

                    if (weaponItemContainer1.childCount < 5)
                    {
                        go = Instantiate(itemInventoryPrefab, weaponItemContainer1);
                    }
                    else
                    {
                        go = Instantiate(itemInventoryPrefab, weaponItemContainer2);
                    }

                    ItemInventory itemInventory = go.GetComponent<ItemInventory>();
                    itemInventory.weapon = weapon;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log($"List weapon single_hand keliatannya masih 0 njirr, detail\n{e}");
        }

        yield return null;
    }

    public void ExamineCharacter(CharacterScriptableObject character)
    {
        ClearWeaponDetails();

        if (character)
        {
            ClearCharacterDetails();

            Instantiate(character.thumbnail, characterPrefabContainer);

            characterName = nameScript.SetTMPText(characterName, character.name);
            characterAttack.text = $"ATK: {character.atkPoint}";
            characterHP.text = $"HP: {character.healthPoint}";
            characterDefense.text = $"DEF: {character.defPoint}";

            characterToEquip = character;
            StartCoroutine(CR_LoadWeaponFromInventory(character.characterJob));
        }
        else
        {
            return;
        }
    }

    public void ExamineWeapon(WeaponScriptableObject weapon)
    {
        if (weapon)
        {
            weaponSpriteContainer.sprite = weapon.weaponThumbnail;

            weaponName = nameScript.SetTMPText(weaponName, weapon.weaponName);
            weaponAttack.text = $"ATK: {weapon.atkPoint}";
            weaponEffect.text = $"ATK: {weapon.specialEffect}";

            weaponToEquip = weapon;
        }
        else
        {
            return;
        }
    }

    public void OnClickEquip()
    {
        if(characterToEquip && weaponToEquip)
        {
            GameManager.Instance.EquipCharacterAndWeapon(characterToEquip, weaponToEquip);
            Close();
        }
        else
        {
            Debug.LogError($"NO CHARACTER & WEAPON TO EQUIP");
            return;
        }
    }

    public void Close()
    {
        ClearCharacterList();
        ClearWeaponList();

        characterToEquip = null;
        weaponToEquip = null;

        canvasMain.OpenMenu(Menu.IN_GAME_MENU, gameObject);
    }

    void ClearCharacterList()
    {
        foreach (Transform c in characterItemContainer)
        {
            Destroy(c.gameObject);
        }
    }

    void ClearWeaponList()
    {
        foreach (Transform c in weaponItemContainer1)
        {
            Destroy(c.gameObject);
        }

        foreach (Transform c in weaponItemContainer2)
        {
            Destroy(c.gameObject);
        }
    }
}
