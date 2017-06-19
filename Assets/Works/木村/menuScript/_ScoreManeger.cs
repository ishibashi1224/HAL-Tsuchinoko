using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ScoreManeger : SingletonMonoBehaviourFast<_ScoreManeger>
{

    private bool ScoreUse;   //menu使用フラグ

	// Use this for initialization
	void Start () {
        ScoreUse = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(ScoreUse)
        {
            //スコア処理
        }
	}

    public bool GetUse()
    {
        return ScoreUse;
    }

    public void SetUse (bool use)
    {
        ScoreUse = use;
    }

}
