﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeltaCollarChange : MonoBehaviour
{
    private float time = 0;
    private float alpha = 0;

    [SerializeField]
    private float interval;

    [SerializeField]
    private Image image;

    // Use this for initialization
    void Start()
    {
        time = 0;
        alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += interval;
        if (time > Mathf.PI * 2)
        {
            time -= Mathf.PI * 2;
        }
        alpha = Mathf.Cos(time);
        if (time < 0)
        {
            time *= -1;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        ResetColor();
    }

    public void ResetColor ()
    {
        if (MenuManager.Instance.GetMode() == MenuManager.MenuModeEnum.MENU)
        {
            if (gameObject.transform.parent.GetChild(0).gameObject.activeSelf)
            {
                image.color = gameObject.transform.parent.GetChild(0).GetComponent<Image>().color;
            }
            else if (gameObject.transform.parent.GetChild(1).gameObject.activeSelf)
            {
                image.color = gameObject.transform.parent.GetChild(1).GetComponent<Image>().color;
            }
            else if (gameObject.transform.parent.GetChild(2).gameObject.activeSelf)
            {
                image.color = gameObject.transform.parent.GetChild(2).GetComponent<Image>().color;
            }
        }
    }
}
