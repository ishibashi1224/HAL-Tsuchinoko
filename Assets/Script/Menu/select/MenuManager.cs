using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : SingletonMonoBehaviourFast<MenuManager>
{

    private bool MenuUse;
    private TutorialManeger tutoriaLmanegeR = null;
    private ScoreManeger scorEmanegeR = null;
    // Use this for initialization
    void Start()
    {
        float screenRate = (float)380 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);

        MenuUse = false;
        tutoriaLmanegeR = TutorialManeger.instance;
        scorEmanegeR = ScoreManeger.instance;
        AudioManager.Instance.PlayBGM("title", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuButton.GetButtonLeft())
        {
            tutoriaLmanegeR.SetUse(true);
            MenuButton.SetButtonLeft(false);
            GetComponent<Scroll>().LeftScroll();
        }

        if (MenuButton.GetButtonRight())
        {
            scorEmanegeR.SetUse(true);
            MenuButton.SetButtonRight(false);
            GetComponent<Scroll>().RightScroll();
        }

        if (!tutoriaLmanegeR.GetUse() && !scorEmanegeR.GetUse())
        {
            //bit入替可能
            //if(↑)
            if (Flick.GetFlick() == "up" && !GrappleObject.GetFlag())
            {
                AudioManager.Instance.PlaySE("Decision");
                //ゲームに遷移
                FadeManager.Instance.LoadLevel("Game", 1);
                BitDataManager.Instance.BitSave();
            }
        }
    }
    public bool GetUse()
    {
        return MenuUse;
    }

    public void SetUse(bool use)
    {
        MenuUse = use;
    }
}
