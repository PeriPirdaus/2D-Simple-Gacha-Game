using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class NameScript
{
    public Color commonColor = Color.red;
    public Color rareColor = Color.green;
    public Color epicColor = Color.blue;

    public TextMeshProUGUI SetTMPText(TextMeshProUGUI tmpObject, string name)
    {
        string rarityName = name;

        if (rarityName.Contains("Epic"))
        {
            tmpObject.color = epicColor;
        }
        else if (rarityName.Contains("Rare"))
        {
            tmpObject.color = rareColor;
        }
        else
        {
            tmpObject.color = commonColor;
        }
        tmpObject.text = $"{rarityName}";
        return tmpObject;
    }
}
