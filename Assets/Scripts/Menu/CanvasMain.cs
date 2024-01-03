using TMPro;
using UnityEngine;

public class CanvasMain : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject mainMenu, inGameMenu, inventoryMenu,
        wishingWellMenu,resultMenu, quitMenu;

    public void OpenMenu(Menu menu, GameObject callingMenu)
    {
        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.IN_GAME_MENU:
                inGameMenu.SetActive(true);
                break;
            case Menu.INVENTORY_MENU:
                inventoryMenu.SetActive(true);
                break;
            case Menu.WISHING_WELL_MENU:
                wishingWellMenu.SetActive(true);
                break;
            case Menu.RESULT_GACHA_MENU:
                resultMenu.SetActive(true);
                break;
            case Menu.QUIT_MENU:
                quitMenu.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }
}

public enum Menu
{
    MAIN_MENU,
    IN_GAME_MENU,
    INVENTORY_MENU,
    WISHING_WELL_MENU,
    RESULT_GACHA_MENU,
    QUIT_MENU
}