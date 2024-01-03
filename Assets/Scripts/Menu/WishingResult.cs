using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishingResult : MonoBehaviour
{
    public CanvasMain canvasMain;
    public GameObject resultParent1;
    public GameObject resultParent2;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClickClose()
    {
        canvasMain.OpenMenu(Menu.IN_GAME_MENU, gameObject);

        foreach(Transform child in resultParent1.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in resultParent2.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
