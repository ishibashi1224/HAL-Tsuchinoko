using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(Flick.GetFlick())
        {
            case "up":
                //FadeManager.Instance.LoadLevel("Game", 1);
                break;

            case "right":
                GetComponent<Scroll>().LeftScroll();
                break;

            case "left":
                GetComponent<Scroll>().RightScroll();
                break;

            default:
                break;
        }
    }
}
