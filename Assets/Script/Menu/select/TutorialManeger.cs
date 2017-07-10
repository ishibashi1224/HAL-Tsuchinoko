using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManeger : SingletonMonoBehaviourFast<TutorialManeger>
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.instance.GetMode() == MenuManager.MenuModeEnum.TUTORIAL)
            //Tutorial処理
            if (MenuButton.GetButtonRight() && !Scroll.GetUse()) //右押したら
            {
                MenuManager.instance.SetModeEnum(MenuManager.MenuModeEnum.MENU);
            }
    }
}
