using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetails : MonoBehaviour
{
    public static ItemDetails Instance {  get; private set; }

    public TextMeshProUGUI itemTitle;

    public NameScript nameScript;

    //characters
    public TextMeshProUGUI atkTitle;
    public TextMeshProUGUI atkPoint;
    public TextMeshProUGUI hpTitle;
    public TextMeshProUGUI hpPoint;
    public TextMeshProUGUI defenseTitle;
    public TextMeshProUGUI defensePoint;

    //weapon
    public TextMeshProUGUI specialEffectTitle;
    public TextMeshProUGUI specialEffect;

    //sprites
    public Image itemImage;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Deactivate();
    }

    public void WeaponDetails(string weaponName, string baseAtk, string effect, Sprite sprite = null)
    {
        Activate();
        ClearValue();

        hpTitle.gameObject.SetActive(false);
        hpPoint.gameObject.SetActive(false);
        defenseTitle.gameObject.SetActive(false);
        defensePoint.gameObject.SetActive(false);

        specialEffectTitle.gameObject.SetActive(true);
        specialEffect.gameObject.SetActive(true);

        itemTitle = nameScript.SetTMPText(itemTitle, weaponName);
        atkPoint.text = baseAtk;
        specialEffect.text = effect;
        itemImage.sprite = sprite;

        itemImage.SetNativeSize();
    }

    public void CharacterDetails(string characterName, string baseAtk, string health, string def, Sprite sprite = null)
    {
        Activate();
        ClearValue();

        specialEffectTitle.gameObject.SetActive(false);
        specialEffect.gameObject.SetActive(false);

        hpTitle.gameObject.SetActive(true);
        hpPoint.gameObject.SetActive(true);
        defenseTitle.gameObject.SetActive(true);
        defensePoint.gameObject.SetActive(true);

        itemTitle = nameScript.SetTMPText(itemTitle, characterName);
        atkPoint.text = baseAtk;
        hpPoint.text = health;
        defensePoint.text = def;
        itemImage.sprite = sprite;

        itemImage.SetNativeSize();
    }

    private void ClearValue()
    {
        atkPoint.text = "";
        hpPoint.text = "";
        defensePoint.text = "";
        specialEffect.text = "";
        itemImage.sprite = null;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
