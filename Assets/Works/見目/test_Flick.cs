using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Flick : MonoBehaviour
{
    private bool isFlick; // フリック
    private bool isClick; // クリック
    private Vector3 touchStartPos; // タッチした始点
    private Vector3 touchEndPos; // タッチした終点
    private int direction; // 方向

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // フリック操作を受け付ける状態にする
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isFlick = true;

            // タッチした時の始点を取得
            touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

            // タッチ時から一定時間後にフリックをfalseにする
            Invoke("FlickOff", 0.2f);
        }

        // 長押しの処理
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // タッチした時の始点を取得（離さない限り常に取得する）
            touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

            // 最初にタッチした位置からズレたらクリックの判定を無くす
            if (touchStartPos != touchEndPos)
            {
                ClickOff();
            }
        }

        // 離した時の処理
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            // タッチした時の終点を取得
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            Debug.Log(touchEndPos);

            // フリックだった場合
            if (IsFlick())
            {
                Debug.Log("Flick");

                // 最初にタッチした位置と離した位置の差分
                float directionX = touchEndPos.x - touchStartPos.x;
                float directionY = touchEndPos.y - touchStartPos.y;

                Debug.Log("DirectionX : " + directionX);
                Debug.Log("DirectionY : " + directionY);

                // 離した位置の方向を判定する
                if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
                {
                    if (0 < directionX)
                    {
                        Debug.Log("Flick : Right");
                        direction = 6;
                    }
                    else
                    {
                        Debug.Log("Flick : Left");
                        direction = 4;
                    }
                }
                else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
                {
                    if (0 < directionY)
                    {
                        Debug.Log("Flick : Up");
                        direction = 8;
                    }
                    else
                    {
                        Debug.Log("Flick : Down");
                        direction = 2;
                    }
                }
                else
                {
                    Debug.Log("Flick : Not, It's Tap");
                    FlickOff();
                }
            }
            else
            {
                Debug.Log("Long Touch");
                direction = 5;
            }
        }
    }

    // Flick Off
    public void FlickOff()
    {
        direction = 5;
        isFlick = false;
    }

    // Is flick
    public bool IsFlick()
    {
        return isFlick;
    }

    // Click On
    public void ClickOn()
    {
        isClick = true;
        Invoke("ClickOff", 0.2f);
    }

    // Id Click
    public bool IsClick()
    {
        return isClick;
    }

    // Click Off
    public void ClickOff()
    {
        isClick = false;
    }
}
