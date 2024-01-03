using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : MonoBehaviour
{
    public CanvasMain canvasMain;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnClickYes()
    {
        Application.Quit();
    }

    public void OnClickNo()
    {
        canvasMain.OpenMenu(Menu.IN_GAME_MENU, gameObject);
    }
}
