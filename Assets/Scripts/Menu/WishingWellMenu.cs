using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishingWellMenu : MonoBehaviour
{
    public CanvasMain canvasMain;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClickOne()
    {
        canvasMain.OpenMenu(Menu.RESULT_GACHA_MENU, gameObject);
    }

    public void OnClickTen()
    {
        canvasMain.OpenMenu(Menu.RESULT_GACHA_MENU, gameObject);
    }

    public void OnClickClose()
    {
        canvasMain.OpenMenu(Menu.IN_GAME_MENU, gameObject);
    }
}
