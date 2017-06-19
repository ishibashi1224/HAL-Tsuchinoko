using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public GameObject Arts;
    private float gageSpeed;
    //private Image 

    // Use this for initialization
    void Start()
    {
        gageSpeed = 0.01f;
        //gageSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(1).transform.gameObject.GetComponent<Image>().fillAmount >= 0)
        {
            transform.GetChild(1).transform.gameObject.GetComponent<Image>().fillAmount -= gageSpeed;
        }
        if (transform.GetChild(1).transform.gameObject.GetComponent<Image>().fillAmount <= 0)
        {
            transform.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }

        if (Arts.activeSelf == true)
        {
            transform.GetChild(1).transform.gameObject.GetComponent<Image>().fillAmount = 1;
            transform.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
    }

    public void artsPush()
    {
        if (Arts.activeSelf == false && transform.GetChild(1).transform.gameObject.GetComponent<Image>().fillAmount <= 0)
        {
            Arts.SetActive(true);
        }
    }
}
