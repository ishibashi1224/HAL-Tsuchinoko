using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexAnim : MonoBehaviour {

    [SerializeField]
    private float width = 1.0f;

    [SerializeField]
    private float height = 1.0f;

    //[SerializeField]
    //private int animTime;

    [SerializeField]
    private int flameTime;

    private Vector2 UVScroll = Vector2.zero;
    private Vector2 UVPos = Vector2.zero;
    private int animCntTime;
    private int cntTime = 0;

    // Use this for initialization
    void Start () {
        UVScroll.x = 1.0f / width;
        UVScroll.y = 1.0f / height;
        UVPos.y = 1.0f - UVScroll.y;
        transform.gameObject.GetComponent<Renderer>().material.mainTextureScale = UVScroll;
        transform.gameObject.GetComponent<Renderer>().material.mainTextureOffset = UVPos;
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        Anim();
    }

    void Anim()
    {
        cntTime++;

        if (cntTime == frame(15))
        {
            if (UVPos.x < 1.0f - UVScroll.x)
            {
                UVPos.x += UVScroll.x;
            }
            else
            {
                UVPos.x = 0.0f;

                if (UVPos.y >= 0.0f + UVScroll.y)
                {
                    UVPos.y -= UVScroll.y;
                }
                else
                {
                    UVPos.y = 0.0f;
                    UVPos.x = 1.0f - UVScroll.x;
                    UVPos = Vector2.zero;
                    UVPos.y = 1.0f - UVScroll.y;
                    //animCntTime--;
                }
            }
            cntTime = 0;
        }

        transform.gameObject.GetComponent<Renderer>().material.mainTextureOffset = UVPos;
    }

    //void TimeMath()
    //{
    //    cntTime++;
    //}

    int frame(int frameCnt)
    {
        int animFrame = 60 / frameCnt;
        return animFrame;
    }
}
