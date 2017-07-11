using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDrawManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuCanvas;

    [SerializeField]
    private GameObject TutorialCanvas;

    [SerializeField]
    private GameObject ScoreCanvas;


    //private static GameObject thisobject;
    private void Awake()
    {
        //        thisobject = this.gameObject;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (MenuManager.Instance.GetMode() == MenuManager.MenuModeEnum.TUTORIAL)
        {
            MenuCanvas.SetActive(true);
            TutorialCanvas.SetActive(true);
            ScoreCanvas.SetActive(false);
        }

        if (MenuManager.Instance.GetMode() == MenuManager.MenuModeEnum.SCORE)
        {
            TutorialCanvas.SetActive(false);
            MenuCanvas.SetActive(true);
            ScoreCanvas.SetActive(true);
        }

        if (MenuManager.Instance.GetMode() == MenuManager.MenuModeEnum.MENU)
        {
            TutorialCanvas.SetActive(false);
            MenuCanvas.SetActive(true);
            ScoreCanvas.SetActive(false);
        }
    }
}
