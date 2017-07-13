using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Arts;

    [SerializeField]
    private float gageSpeed;
    //private Image 

    // Use this for initialization
    void Start()
    {
        //gageSpeed = 0.01f;
        //gageSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.root.GetChild(3).gameObject.activeSelf == false )
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
    }

    public void artsPush()
    {
        if (Arts.activeSelf == false && transform.GetChild(1).transform.gameObject.GetComponent<Image>().fillAmount <= 0)
        {
            if(BitTrueFalse() == true)
            {
                if (transform.root.GetChild(3).gameObject.activeSelf == false)
                {
                    AudioManager.Instance.PlaySE("Tripanish");
                    Arts.SetActive(true);
                }
            }
        }
    }

    bool BitTrueFalse()
    {
        if( Arts.transform.root.gameObject.transform.GetChild(0).GetChild(0).GetComponent<BitLife>().lifeTrueFalse() == true &&
            Arts.transform.root.gameObject.transform.GetChild(1).GetChild(0).GetComponent<BitLife>().lifeTrueFalse() == true &&
            Arts.transform.root.gameObject.transform.GetChild(2).GetChild(0).GetComponent<BitLife>().lifeTrueFalse() == true )
        {
            return true;
        }
        return false;
    }
}
