using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeltaCollarChange : MonoBehaviour
{
    //  private Image image = GetComponent<Image>();
    [SerializeField]
    private Image image;

    [SerializeField]
    private float interval;
    // Use this for initialization
    float time = 0;
    float alpha = 0;
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

        /*if (TutorialManeger.Instance.GetUse())
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }

        if (ScoreManeger.Instance.GetUse())
        {

        }*/
    }
}
