using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TutorialManeger : SingletonMonoBehaviourFast<_TutorialManeger>
{

    private bool TutorialUse;      //メニュー使用フラグ

	// Use this for initialization
	void Start () {
    TutorialUse = false;
    }

    // Update is called once per frame
    void Update () {
		if(TutorialUse)
        {
            //Tutorial処理
        }

        //if(right) //右押したら
        //{
        //    Set
        //}
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
