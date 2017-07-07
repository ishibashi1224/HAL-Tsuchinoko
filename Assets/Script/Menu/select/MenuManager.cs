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
    [SerializeField]
    Canvas MenuCanvas = null;

    public enum MenuModeEnum
    {
        NONE,
        MENU,
        TUTORIAL,
        SCORE 
    }

    private static MenuModeEnum e_MenuModeEnum = MenuModeEnum.NONE;
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
        targetcnt = 0;
        //MenuUse = false;
        //tutoriaLmanegeR = TutorialManeger.instance;
        //scorEmanegeR = ScoreManeger.instance;

        //AudioManager.Instance.PlayBGM("title", true);
    }

    // Update is called once per frame
    void Update()
    {
        //過去の
        //e_MenuModeEnum_Old = e_MenuModeEnum;

        if (e_MenuModeEnum == MenuModeEnum.NONE && !Scroll.GetUse())
        {
            cnt++;
            if (cnt > targetcnt)
            {
                Debug.Log("Enum : " + e_MenuModeEnum.ToString());
                //e_MenuModeEnum = MenuModeEnum.MENU;
                SetModeEnum(MenuModeEnum.MENU);
                Debug.Log("Enum : " + e_MenuModeEnum.ToString());

                cnt = 0;

            }
        }

        if ( e_MenuModeEnum == MenuModeEnum.MENU )
        //if (!tutoriaLmanegeR.GetUse() && !scorEmanegeR.GetUse())
        {
            if (MenuButton.GetButtonLeft()&& !Scroll.GetUse()&& e_MenuModeEnum_Old == MenuModeEnum.NONE /*&& tutoriaLmanegeR.GetChange()==false&& scorEmanegeR.GetChange()==false*/)
            {
                e_MenuModeEnum = MenuModeEnum.TUTORIAL;
                //tutoriaLmanegeR.SetUse(true);
                MenuButton.SetButtonLeft(false);
                GetComponent<Scroll>().LeftScroll();
            }
            else
            //if
            if (MenuButton.GetButtonRight()&& !Scroll.GetUse()/*&& scorEmanegeR.GetChange() == false&& tutoriaLmanegeR.GetChange() == false*/)
            {
                if (e_MenuModeEnum_Old != MenuModeEnum.NONE)
                {
                    e_MenuModeEnum = MenuModeEnum.SCORE;
                }
                else
                {
                    SetModeEnum(MenuModeEnum.MENU);
                }
                //scorEmanegeR.SetUse(true);
                MenuButton.SetButtonRight(false);
                GetComponent<Scroll>().RightScroll();
            }
            Debug.Log("Enum : " + e_MenuModeEnum.ToString());
        //Debug.Log("TutoriaL : " + tutoriaLmanegeR.GetUse().ToString());


        /*if (tutoriaLmanegeR.GetChange()==true)
        {
            tutoriaLmanegeR.ResetChange();

        }
        else
        if (scorEmanegeR.GetChange()==true)
        {
            scorEmanegeR.ResetChange();
        }*/

            //bit入替可能
            //if(↑)
            if (Flick.GetFlick() == "up" && !GrappleObject.GetFlag())
            {
//                AudioManager.Instance.PlaySE("Decision");
                //ゲームに遷移
                FadeManager.Instance.LoadLevel("Game", 1);
                BitDataManager.Instance.BitSave();
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
