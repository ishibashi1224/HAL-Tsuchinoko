using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeger : SingletonMonoBehaviourFast<ScoreManeger>
{
    private bool ScoreUse;   //menu使用フラグ

    [SerializeField]
    Canvas RankingCanvas = null;

    // Use this for initialization
    void Start () {
        ScoreUse = false;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (ScoreUse)
        {
            //...
            //score処理
            if (MenuButton.GetButtonLeft()) //右押したら
            {
                ScoreUse = false;

            }

            
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
