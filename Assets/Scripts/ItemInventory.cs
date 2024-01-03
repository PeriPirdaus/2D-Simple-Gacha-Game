using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
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
        if (weapon != null)
        {
            InventoryMenu.instance.ExamineWeapon(weapon);
        }
        else
        {
            InventoryMenu.instance.ExamineCharacter(character);
        }
    }

    private void OnDestroy()
    {
        weapon = null;
        character = null;
        _image.sprite = null;
    }
}
