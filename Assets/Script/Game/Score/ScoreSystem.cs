using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Enemy = new List<GameObject>();

    [SerializeField]
    private Text ScoreText = null;

    // ランキングキー（データ保存用）
    const string Ranking_Key = "Ranking";

    // ハイスコアキー（データ保存用）
    const string High_Score_Key = "HighScore";

    // スコアキー（データ保存用）
    const string Score_Key = "Score";

    // ハイスコア値
    static int HighScore = 0;

    // 現在スコア値
    static int Score = 0;

    int nCnt = 0;

    // ランキング番号
    private float[] ranking = new float[5];

    // スコアのセーブ
    static public void SaveScore()
    {
        PlayerPrefs.SetInt(High_Score_Key, Score);
        PlayerPrefs.Save();
    }

    // スコアのロード
    static public int LoadScore()
    {
        return PlayerPrefs.GetInt(High_Score_Key, -1);
    }

    // スコアの加算
    static public void AddScore(int addScore)
    {
        Score += addScore;
    }

    // スコアの減算
    static public void SubtractScore(int subScore)
    {
        Score -= subScore;
    }

    // スコアを比較し、ランキングを決める
    void ComparisonRanking()
    {
        var _ranking = PlayerPrefs.GetString(Ranking_Key);

        if (_ranking.Length > 0)
        {
            var _score = _ranking.Split(","[0]);

            for (var i = 0; i < _score.Length && i < 5; i++)
            {
                // 文字列をfloat型に変更
                ranking[i] = float.Parse(_score[i]);
            }
        }
    }

    // 新たなスコア保存
    void SeveRanking(float new_score)
    {
        if (ranking != null)
        {
            float num = 0.0f;

            for (var i = 0; i < ranking.Length; i++)
            {
                num = ranking[i];
                ranking[i] = new_score;
                new_score = num;
            }
        }
        else
        {
            ranking[0] = new_score;
        }
    }

    // ランキング表示
    void DrawRanking()
    {

    }

    // Use this for initialization
    void Start()
    {
        SaveScore();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "SCORE:  " + Score.ToString() + "\n" + "HIGH SCORE:  " + HighScore.ToString(); ;

        
        nCnt++;
        if (nCnt >= 20)
        { 
            Score += 1;
            if (Score == 100)
            {
                SaveScore();
            }
            else if (Score == 200)
            {
                SaveScore();
            }

            nCnt = 0;
        }
    }

    void OnGUI()
    {
        float x = Screen.width / 10;
        float y = 150;
        float w = Screen.width * 8 / 10;
        float h = Screen.height / 20;

        // デバッグ表示 現在スコア値の表示
        GUI.Label(new Rect(x, y, w, h), "Score : " + Score);

        // ハイスコアの取得
        HighScore = LoadScore();

        // デバッグ ハイスコア値の表示
        GUI.Label(new Rect(x, y + 50, w, h), "HighScore : " + HighScore);
    }
}
