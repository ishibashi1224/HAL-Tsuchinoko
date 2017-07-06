using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaButtonManager : MonoBehaviour {
    private GameObject  leftbutton;

    private void Awake()
    {
    }
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        if (TutorialManeger.Instance.GetUse())
        {
            //GameObject.Find("Canvas").transform.Find("MenuPanel").gameObject.SetActive(true);

            gameObject.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                if (transform.root.GetChild(i).gameObject.activeSelf == false)
                {
                    transform.root.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
        else
        {

            //leftbutton.SetActive(true);
        }
	}


}
