using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviourFast<GameManager>
{
    [SerializeField]
    private float FadeTime = 1.0f;  //  フェードにかける時間。
    [SerializeField]
    private float Interval = 0.0f;
    [SerializeField]
    private string FadeSceneName = null;   //  フェードするシーン名
    [SerializeField]
    private GameObject MapList = null;
    [SerializeField]
    private GameObject Clear;
    [SerializeField]
    private GameObject GameOver;
    private float time;

    private void Awake()
    {
        Application.targetFrameRate = 60;//フレームレートを60にする
    }

    // Use this for initialization
    void Start()
    {
        float screenRate = (float)380 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);
        AudioManager.Instance.PlayBGM("Game_loop_Ml", true);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("EnemyBoss").Length <= 0)
        {
            if(time == 0.0f)
            {
                ScoreSystem.instance.RankingUpdate();
                ScoreSystem.Instance.enabled = false;
            }
            
            if (time >= Interval && !FadeManager.GetFadeing())
            {
                Clear.SetActive(true);
                //AudioManager.instance.PlayBGM("victory", false);
                Time.timeScale = 0;
            }
            time += Time.deltaTime;
        }
        else
        {
            ScoreSystem.Instance.enabled = true;
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
