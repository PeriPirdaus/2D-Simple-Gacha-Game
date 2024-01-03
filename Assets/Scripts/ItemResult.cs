using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemResult : MonoBehaviour
{
    public WeaponScriptableObject weapon;
    public CharacterScriptableObject character;
    [SerializeField] private Image _image;

    private void Start()
    {
        if (weapon != null)
        {
            _image.sprite = weapon.weaponThumbnail;
        }
        else
        {
            _image.sprite = character.charSprite;
        }
    }

    public void OnClickDetails()
    {
        if(weapon != null)
        {
            ItemDetails.Instance.WeaponDetails(weapon.weaponName, weapon.atkPoint.ToString(), weapon.specialEffect.ToString(), weapon.weaponThumbnail);
        }
        else
        {
            ItemDetails.Instance.CharacterDetails(character.charName, character.atkPoint.ToString(), character.healthPoint.ToString(), character.defPoint.ToString(), character.charSprite);
        }
    }

    private void OnDestroy()
    {
        weapon = null;
        character = null;
        _image.sprite = null;
    }
}
