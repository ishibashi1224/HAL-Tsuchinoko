using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arts : MonoBehaviour {

    private Vector2 UVScroll = Vector2.zero;
    private Vector2 UVPos = Vector2.zero;
    private int time = 0;
    private bool loop;
    public int defaultAnimTime;
    private int animTime;
    private Vector3 defoltScale;

    // Use this for initialization
    void Start () {
        UVScroll.x = 1.0f/8.0f;
        UVScroll.y = 1.0f/2.0f;
        UVPos.y = 1.0f - UVScroll.y;
        transform.GetChild(3).transform.gameObject.GetComponent<Renderer>().material.mainTextureScale = UVScroll;
        transform.GetChild(3).transform.gameObject.GetComponent<Renderer>().material.mainTextureOffset = UVPos;
        loop = true;
        transform.GetChild(3).transform.gameObject.GetComponent<Renderer>().sortingOrder = -1;
        animTime = defaultAnimTime;
        defoltScale = transform.GetChild(3).transform.GetChild(0).localScale;
        transform.GetChild(3).transform.GetChild(0).localScale = new Vector3( 0.0f , 0.0f , 0.0f );
    }

    // Update is called once per frame
    void Update() {
        if (transform.GetChild(3).transform.gameObject.activeSelf == true)
        {
            Anim();
        }
        else
        {
            loop = true;
            UVPos = Vector2.zero;
            UVPos.y = 1.0f - UVScroll.y;
            transform.GetChild(3).transform.gameObject.GetComponent<Renderer>().material.mainTextureOffset = UVPos;
            animTime = defaultAnimTime;
            transform.GetChild(3).transform.GetChild(0).localScale = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    void Anim()
    {
        time++;

        if (animTime >= 0)
        {
            if (time == frame(15))
            {
                if (loop == true)
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
                            //loop = false;
                            animTime--;                        
                        }
                    }
                }
                time = 0;
            }
        }
        else
        {
            transform.GetChild(3).transform.gameObject.SetActive(false);
        }

        if(transform.GetChild(3).transform.gameObject.activeSelf == true )
        {
            if(animTime == defaultAnimTime)
            {
                transform.GetChild(3).transform.GetChild(0).localScale += ( defoltScale - transform.GetChild(3).transform.GetChild(0).localScale ) * 0.1f;
            }

            if (animTime == 0)
            {
                transform.GetChild(3).transform.GetChild(0).localScale += ( new Vector3(0.0f, 0.0f, 0.0f) - transform.GetChild(3).transform.GetChild(0).localScale) * 0.05f;
            }
        }

        transform.GetChild(3).transform.gameObject.GetComponent<Renderer>().material.mainTextureOffset = UVPos;
    }

    int frame( int frameCnt )
    {
        int animFrame = 60 / frameCnt;
        return 60 / frameCnt;
    }
}
