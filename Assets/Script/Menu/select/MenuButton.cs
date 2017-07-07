using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        Top = true;
    }

    public void ButtonPushLeft()
    {
        left = true;
    }

    public void ButtonPushRight()
    {
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
        left = use;
    }

    public static void SetButtonRight(bool use)
    {
        Right = use;
    }

    public static void SetButtonTop(bool use)
    {
        Debug.Log("SetButtonTop");
        Top = use;
    }
}
