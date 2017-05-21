using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFlick : MonoBehaviour
{
    [SerializeField]
    private float move = 0.0f;
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    // Use this for initialization
    void Start()
    {
        touchStartPos = new Vector3(0, 0, 0);
        touchEndPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            GetDirection();
        }
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        string Direction = "";

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                Direction = "down";
            }
        }
        else
        {
            //タッチを検出
            Direction = "touch";
        }

        switch (Direction)
        {
            case "up":
                Debug.Log("up");
                break;

            case "down":
                Debug.Log("down");
                break;

            case "right":
                Debug.Log("right");
                transform.localPosition += new Vector3(move, 0, 0);
                break;

            case "left":
                Debug.Log("left");
                transform.localPosition -= new Vector3(move, 0, 0);
                break;

            case "touch":
                Debug.Log("touch");
                break;
        }
    }
}
