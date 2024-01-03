using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public CanvasMain canvasMain;
    public void OnClickStart()
    {
        canvasMain.OpenMenu(Menu.IN_GAME_MENU, gameObject);
    }
}
