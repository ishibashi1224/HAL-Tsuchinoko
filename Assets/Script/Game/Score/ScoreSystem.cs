using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreSystem : SingletonMonoBehaviourFast<ScoreSystem>
{
    [SerializeField]
    private List<GameObject> Enemy = new List<GameObject>();

    [SerializeField]
    private Text TimeText;

    // ランキングキー（データ保存用）
    const string Ranking_Key = "Ranking";

    // ハイタイムキー（データ保存用）
    const string High_Score_Key = "HighScore";

    // 現在の秒時刻
    static public float fSecond = 0.0f;

    // 現在の分時刻
    static public float fMinute = 0.0f;

    // 現在の時間
    static public float fTime = 0.0f;

    // 最速時間時刻
    static public float fHighTime = 99.0f;

    // ランキング保存用フラグ処理（一回のみ実行する為）
    bool bGameOver = false;

    // フレームフラグ処理（一回のみ実行する為）
    bool bFrame = false;

    // フレーム管理
    int nCnt = 0;

    // ランキング番号（ランキング配列[0]番がハイタイムとなる）
    static public List<float> ranking = new List<float>();

    // ハイタイムセーブ
    static public void SaveHighScore()
    {
        PlayerPrefs.SetFloat(High_Score_Key, fHighTime);
        PlayerPrefs.Save();
    }

    // ハイタイムのロード
    static public float LoadHighScore()
    {
        return PlayerPrefs.GetFloat(High_Score_Key);
    }

    // タイムの加算
    static public void AddScore(float addScore)
    {
        fTime += addScore;
    }

    // タイムの減算
    static public void SubtractScore(float subScore)
    {
        fTime -= subScore;
    }

    // タイムを比較し、ランキングを決める
    void ComparisonRanking()
    {
        ranking.Sort();
    }

    // 新たなタイム保存
    static public void SaveRanking(float time)
    {
        ranking.Add(time);

        ranking.Sort();

        ranking.RemoveAt(5);
    }


    void UpdateTime(float time)
    {
        fMinute = (int)fTime / 60;
        fSecond = (int)fTime % 60;
        TimeText.text = fMinute.ToString(string.Format("00")) + ":" + fSecond.ToString(string.Format("00"));
    }

    // ランキング更新
    public void RankingUpdate()
    {
        // 前回のハイタイムを取得
        fHighTime = LoadHighScore();

        SaveRanking(fTime);

        fTime = 0.0f;
    }

    // Use this for initialization
    void Start()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     // ゲーム中のみタイムを加算されるフラグ判定
     // if (bFrame == false)
        {
            // タイム加算
            AddScore(Time.deltaTime);

            // タイムのテキスト更新
            UpdateTime(fTime);
            
        }
    }

    // デバッグ表示
    void OnGUI()
    {
        float x = Screen.width / 10;
        float y = 150;
        float w = Screen.width * 8 / 10;
        float h = Screen.height / 20;

        // GUI.Label(new Rect(x, y + 80, w, h), "1.　" + ranking[0].ToString(string.Format("00", (int)fTime / 60)) + ":" + string.Format("00",(int)fTime % 60));

    }
}
