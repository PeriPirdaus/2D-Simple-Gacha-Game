using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public CanvasMain canvasMain;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
#if UNITY_ANDROID
        if(Input.GetKeyDown(KeyCode.Escape) && gameObject.activeInHierarchy)
        {
            canvasMain.OpenMenu(Menu.QUIT_MENU, gameObject);
        }
#endif

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Q) && gameObject.activeInHierarchy)
        {
            canvasMain.OpenMenu(Menu.QUIT_MENU, gameObject);
        }
#endif
    }

    public void OnClickInventory()
    {
        canvasMain.OpenMenu(Menu.INVENTORY_MENU, gameObject);
    }

    public void OnClickWell()
    {
        canvasMain.OpenMenu(Menu.WISHING_WELL_MENU, gameObject);
    }

    public void OnClickBattle()
    {
        
    }
}
