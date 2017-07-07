using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeger : SingletonMonoBehaviourFast<ScoreManeger>
{
    //private bool ScoreUse;   //menu使用フラグ
    //private static bool ScoreChange;
    [SerializeField]
    Canvas RankingCanvas = null;

    // Use this for initialization
    void Start () {
    //    ScoreUse = false;
     //   ScoreChange = false;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (MenuManager.instance.GetMode() == MenuManager.MenuModeEnum.SCORE)
        {
            //...
            //score処理
            //if (MenuManager.instance.GetMode() == MenuManager.MenuModeEnum.SCORE)
            if (MenuButton.GetButtonLeft()&& !Scroll.GetUse()) //右押したら
            {
                MenuManager.instance.SetModeEnum(MenuManager.MenuModeEnum.MENU);
                //TutorialManeger.instance.SetUse(false);
                //TutorialManeger.instance.SetChange(true);
                //MenuManager.instance.SetUse(true);
                //ScoreChange = true;
                return;
                
            }

            
        }
    }

    /*public bool GetUse()
    {
        return ScoreUse;
    }

    public void SetUse (bool use)
    {
        ScoreUse = use;
    }

    public bool GetChange()
    {
        return ScoreChange;
    }

    public void ResetChange()
    {
        ScoreChange = false;
    }

    public void SetChange(bool use)
    {
        ScoreChange = use;
    }
    */
}
