using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManeger : SingletonMonoBehaviourFast<TutorialManeger>
{
    //private static bool TutorialChange;
    //private bool TutorialUse;      //メニュー使用フラグ

    [SerializeField]
    Canvas TutorialCanvas = null;

    // Use this for initialization
    void Start()
    {
   //     TutorialUse = false;
    //    TutorialChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuManager.instance.GetMode() == MenuManager.MenuModeEnum.TUTORIAL)
        //if (TutorialUse)
        {
            //Tutorial処理
            if(MenuButton.GetButtonRight()&& !Scroll.GetUse()) //右押したら
            {

                //TutorialUse = false;
                MenuManager.instance.SetModeEnum(MenuManager.MenuModeEnum.MENU);
                //ScoreManeger.instance.SetUse(false);
                //MenuManager.instance.SetUse(true);
                //TutorialChange = true;
                //ScoreManeger.instance.SetChange(true);

            }
        }


    }


   /* public bool GetUse()
    {
        return TutorialUse;
    }

    public void SetUse(bool use)
    {
        TutorialUse = use;
    }

    public bool GetChange()
    {
        return TutorialChange;
    }

    public void ResetChange()
    {
        TutorialChange = false;
    }

    public void SetChange(bool use)
    {
        TutorialChange = use;
    }*/
}
