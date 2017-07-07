using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingMove : MonoBehaviour
{
    private GameObject gameobject;
    private static Vector3 workpos = new Vector3(); //復旧用
    private bool moveflag = false;
    private ScoreManeger workScoreManager;
    private float rate = 0.0f;
    // Use this for initialization
    void Start()
    {
        gameobject = this.gameObject;
        moveflag = false;
        workScoreManager = ScoreManeger.Instance;
        workpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.Instance.GetMode()== MenuManager.MenuModeEnum.SCORE)
        {
            if (this.transform.position.x <= SurfaceGetter.GetPos().x && moveflag)
            {
                rate = 0.0f;
                moveflag = false;
            }
            else
            {
                rate += 0.01f;
                //transform.position += new Vector3((SurfaceGetter.GetPos().x- transform.position.x)*0.5f,transform.position.y,transform.position.z);
                //transform.position.x +=(SurfaceGetter.GetPos().x - transform.position.x) * 0.5f;
                transform.position = Vector3.Lerp(SurfaceGetter.GetPos(), transform.position, rate);
                 moveflag = true;
            }
        }
        else
        {
            transform.position = workpos;
        }

    }
}
 