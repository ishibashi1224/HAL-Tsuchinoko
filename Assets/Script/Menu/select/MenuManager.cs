using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : SingletonMonoBehaviourFast<MenuManager>
{
    public enum MenuModeEnum
    {
        NONE,
        MENU,
        TUTORIAL,
        SCORE
    }

    private static MenuModeEnum e_MenuModeEnum = MenuModeEnum.MENU;
    private static MenuModeEnum e_MenuModeEnum_Old = e_MenuModeEnum;
    private int cnt = 0;
    private int targetcnt = 0;
    private bool waitbull = false;
    private bool inputwait = false;

    // Use this for initialization
    void Start()
    {
        float screenRate = (float)380 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);
        cnt = 0;
        targetcnt = 5;
        AudioManager.Instance.PlayBGM("title", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!FadeManager.GetFadeing() &&
            e_MenuModeEnum == MenuModeEnum.MENU &&
            !Scroll.GetUse())
        {
            if (MenuButton.GetButtonLeft() && !inputwait)       //左を押したら
            {
                if (e_MenuModeEnum_Old == MenuModeEnum.SCORE)   //昔のモードがスコアだったら
                {
                    waitbull = true;
                    GetComponent<Scroll>().LeftScroll();
                    MenuButton.SetButtonLeft(false);
                    MenuButton.SetButtonRight(false);
                }
                else if (!waitbull)
                {
                    SetModeEnum(MenuModeEnum.TUTORIAL);
                    MenuButton.SetButtonLeft(false);
                    GetComponent<Scroll>().LeftScroll();
                }
                inputwait = true;
            }

            if (MenuButton.GetButtonRight() &&
                !inputwait)
            {
                if (e_MenuModeEnum_Old == MenuModeEnum.TUTORIAL)
                {
                    waitbull = true;
                    GetComponent<Scroll>().RightScroll();
                    MenuButton.SetButtonRight(false);
                    MenuButton.SetButtonLeft(false);
                }
                else if (!waitbull)
                {
                    SetModeEnum(MenuModeEnum.SCORE);
                    MenuButton.SetButtonRight(false);
                    MenuButton.SetButtonLeft(false);
                    GetComponent<Scroll>().RightScroll();
                }
                inputwait = true;
            }

            if (waitbull)
            {
                cnt++;
                if (cnt > targetcnt / 2)
                {
                    SetModeEnum(MenuModeEnum.MENU);
                    cnt = 0;
                    waitbull = false;
                }
            }
            else if (inputwait)
            {
                cnt++;
                if (cnt > targetcnt)                        
                {
                    cnt = 0;
                    inputwait = false;
                }
            }

            if (MenuButton.GetButtonTop())                  //上のボタンを押したら
            {
                AudioManager.Instance.PlaySE("決定");   //SEを鳴らす
                FadeManager.Instance.LoadLevel("Game", 1);  //ゲームに遷移
                BitDataManager.Instance.BitSave();          //ビット状態保存
            }
        }
    }

    //メニューの内部遷移モードのゲッター
    public MenuModeEnum GetMode()
    {
        return e_MenuModeEnum;
    }

    //メニューの内部遷移モードのセッター
    public void SetModeEnum(MenuModeEnum Enum)
    {
        e_MenuModeEnum_Old = e_MenuModeEnum;
        e_MenuModeEnum = Enum;
        cnt = 0;
    }
}
