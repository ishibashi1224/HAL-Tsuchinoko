using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : SingletonMonoBehaviourFast<MenuManager>
{

    //private bool MenuUse;
    //private TutorialManeger tutoriaLmanegeR = null;
    //private ScoreManeger scorEmanegeR = null;
    private int cnt = 0;
    private int targetcnt = 0;
    private bool waitbull = false;
    private bool inputwait = false;
    [SerializeField]
    Canvas MenuCanvas = null;

    public enum MenuModeEnum
    {
        NONE,
        MENU,
        TUTORIAL,
        SCORE 
    }

    private static MenuModeEnum e_MenuModeEnum = MenuModeEnum.MENU;
    private static MenuModeEnum e_MenuModeEnum_Old = e_MenuModeEnum;
    // Use this for initialization
    void Start()
    {
        float screenRate = (float)380 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);
        cnt = 0;
        targetcnt = 1*5;
        //MenuUse = false;
        //tutoriaLmanegeR = TutorialManeger.instance;
        //scorEmanegeR = ScoreManeger.instance;

        //AudioManager.Instance.PlayBGM("title", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!FadeManager.GetFadeing())
        {
            if (e_MenuModeEnum == MenuModeEnum.MENU)
            {
                if (!inputwait)
                {
                    if (MenuButton.GetButtonLeft() && !Scroll.GetUse())
                    {
                        if (e_MenuModeEnum_Old == MenuModeEnum.SCORE)
                        {
                            waitbull = true;
                            GetComponent<Scroll>().LeftScroll();
                            MenuButton.SetButtonLeft(false);
                            MenuButton.SetButtonRight(false);
                        }
                        else if (!waitbull)
                        {

                            SetModeEnum(MenuModeEnum.TUTORIAL);
                            //tutoriaLmanegeR.SetUse(true);
                            MenuButton.SetButtonLeft(false);
                            GetComponent<Scroll>().LeftScroll();
                        }
                        inputwait = true;
                    }

                    //if
                    if (MenuButton.GetButtonRight() && !Scroll.GetUse())
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
                    
                }

                if (waitbull && !Scroll.GetUse())
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
                Debug.Log("Enum : " + e_MenuModeEnum.ToString());

                //bit入替可能
                //if(↑)
                if (/*Flick.GetFlick() == "up" && !GrappleObject.GetFlag() ||*/ MenuButton.GetButtonTop())
                {
                    //                AudioManager.Instance.PlaySE("Decision");
                    //ゲームに遷移
                    FadeManager.Instance.LoadLevel("Game", 1);
                    BitDataManager.Instance.BitSave();
                }
            }
        }
    }
    /*public bool GetUse()
    {
        return MenuUse;
    }

    public void SetUse(bool use)
    {
        MenuUse = use;
    }*/

    public MenuModeEnum GetMode()
    {
        return e_MenuModeEnum;
    }

    public void SetModeEnum (MenuModeEnum Enum)
    {
        e_MenuModeEnum_Old = e_MenuModeEnum;
        e_MenuModeEnum = Enum;
        cnt = 0;
    }
}
