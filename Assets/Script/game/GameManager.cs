﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviourFast<GameManager>
{
    [SerializeField]
    private float FadeTime = 1.0f;  //  フェードにかける時間。
    [SerializeField]
    private string FadeSceneName = null;   //  フェードするシーン名
    [SerializeField]
    private GameObject MapList = null;
    [SerializeField]
    private GameObject Clear;
    [SerializeField]
    private GameObject GameOver;

    // Use this for initialization
    void Start()
    {
        float screenRate = (float)380 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);
        AudioManager.Instance.PlayBGM("Game_loop_Ml", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("EnemyBoss").Length <= 0)
        {
            if (!FadeManager.GetFadeing())
            {
                Clear.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Scene()
    {
        if (!FadeManager.GetFadeing())
        {
            Time.timeScale = 1;
            FadeManager.Instance.LoadLevel(FadeSceneName, FadeTime);
        }
    }
}
