using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaButtonManager : MonoBehaviour {
    [SerializeField]
    private GameObject  leftbutton;

    //private static GameObject thisobject;
    private void Awake()
    {
//        thisobject = this.gameObject;
    }
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        if (MenuManager.Instance.GetMode() == MenuManager.MenuModeEnum.TUTORIAL )
        {
            //GameObject.Find("Canvas").transform.Find("MenuPanel").gameObject.SetActive(true);

            //gameObject.SetActive(!gameObject.activeSelf);
            leftbutton.SetActive(false);
        }
        else
        {
            //leftbutton.active= true;
            leftbutton.SetActive(true);
        }
	}

/*    public static GameObject GetGameObject()
    {
        return thisobject;
    }

    public static void SetActiveOperator(bool use)
    {
        thisobject.SetActive(use);
    }
    */
}
