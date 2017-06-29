using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private static bool left;
    private static bool Right;
    private static bool Top;

    // Use this for initialization
    void Start()
    {
        left = false;
        Right = false;
        Top = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonPushTop()
    {
        Debug.Log("ButtonPuchTop=true");
        Top = true;
    }

    public void ButtonPushLeft()
    {
        Debug.Log("ButtonPuchleft=true");
        left = true;
    }

    public void ButtonPushRight()
    {
        Debug.Log("ButtonPuchRight=true");
        Right = true;
    }


    public static bool GetButtonLeft()
    {
        return left;
    }

    public static bool GetButtonRight()
    {
        return Right;
    }

    public static bool GetButtonTop()
    {
        return Top;
    }

    public static void SetButtonLeft(bool use)
    {
        Debug.Log("SetButtonLeft");
        left = use;
    }

    public static void SetButtonRight(bool use)
    {
        Debug.Log("SetButtonRight");
        Right = use;
    }

    public static void SetButtonTop(bool use)
    {
        Debug.Log("SetButtonTop");
        Top = use;
    }

    public static void SetDrawLeft(bool use)
    {
        
    }


}
