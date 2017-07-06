using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManeger : SingletonMonoBehaviourFast<TutorialManeger>
{

    private bool TutorialUse;      //メニュー使用フラグ

    [SerializeField]
    Canvas TutorialCanvas = null;

    // Use this for initialization
    void Start()
    {
        TutorialUse = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (TutorialUse)
        {
            //Tutorial処理
            if(MenuButton.GetButtonRight()) //右押したら
            {
                TutorialUse = false;   
            }
        }


    }


    public bool GetUse()
    {
        return TutorialUse;
    }

    public void SetUse(bool use)
    {
        TutorialUse = use;
    }
}
