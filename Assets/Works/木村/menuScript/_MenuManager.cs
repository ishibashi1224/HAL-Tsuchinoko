using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MenuManager : SingletonMonoBehaviourFast<_MenuManager>
{

    private bool MenuUse;
    private _TutorialManeger tutoriaLmanegeR = null;
    private _ScoreManeger scorEmanegeR = null;
    // Use this for initialization
    void Start()
    {
        MenuUse = false;
        tutoriaLmanegeR = _TutorialManeger.instance;
        scorEmanegeR = _ScoreManeger.instance;
    }

    // Update is called once per frame
    void Update()
    {

        if (!tutoriaLmanegeR.GetUse() && !scorEmanegeR.GetUse())
        {
            //bit入替可能
            //if(↑)
            if (Flick.GetFlick() == "up")
            {
                //ゲームに遷移
                FadeManager.Instance.LoadLevel("Game", 1);
            }
        }
        else
        {
            
            //if (Left)         //もし左押したら
            //{
            //  tutoriaLmanegeR.SetUse(true);
            //}
            //else if (right)   //それ以外でもし右押したら
            //{
            //  scorEmanegeR.SetUse(true);
            //}
        }
    }

    public void SetUse(bool use)
    {
        MenuUse = use;
    }
}
