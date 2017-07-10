using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeger : SingletonMonoBehaviourFast<ScoreManeger>
{
    // Use this for initialization
    void Start()
    {
        //    ScoreUse = false;
        //   ScoreChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.instance.GetMode() == MenuManager.MenuModeEnum.SCORE)
        {
            if (MenuButton.GetButtonLeft() && !Scroll.GetUse()) //右押したら
            {
                MenuManager.instance.SetModeEnum(MenuManager.MenuModeEnum.MENU);
                return;
            }
        }
    }
}
