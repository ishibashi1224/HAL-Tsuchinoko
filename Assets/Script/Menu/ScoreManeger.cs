using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeger : SingletonMonoBehaviourFast<ScoreManeger>
{
    private bool ScoreUse;   //menu使用フラグ
    private GameObject plane;
    // Use this for initialization
    void Start () {
        ScoreUse = false;
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0, 0, 0);
        plane.SetActive(false);
    }
	
    // Update is called once per frame
    void Update()
    {
        if (ScoreUse)
        {
            //...
            //score処理
            if(MenuButton.GetButtonLeft()) //右押したら
            {
                ScoreUse = false;
                plane.SetActive(ScoreUse);

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
        plane.SetActive(use);
    }

}
