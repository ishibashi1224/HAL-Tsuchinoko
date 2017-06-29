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

    // ハイスコア値
    static int HighScore = 0;

    // 現在スコア値
    static int Score = 0;

    // フレーム管理
    int nCnt = 0;

    // ランキング番号
    static public int[] ranking = new int[5];

    // ハイスコアセーブ
    static public void SaveHighScore()
    {
        PlayerPrefs.SetInt(High_Score_Key, HighScore);
        PlayerPrefs.Save();
    }

    // ハイスコアのロード
    static public int LoadHighScore()
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
                // 文字列をint型に変更
                ranking[i] = int.Parse(_score[i]);
            }
        }
    }

    // 新たなスコア保存
    void SeveRanking(int new_score)
    {
        if (ranking != null)
        {
            int num = 0;

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

    // Use this for initialization
    void Start()
    {
        // 初期ハイスコア値保存（念の為）
        SaveHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        // フレーム規制
        nCnt++;
        if (nCnt >= 2)
        {
            nCnt = 0;

            // スコア加算（仮・「本来はステージクリア毎にスコアを加算」）
            AddScore(1);

            // スコアのフラグ値判定
            if(Score == 100)
            {
                // 前回のハイスコアを取得
                HighScore = LoadHighScore();

                // 現在のスコアと前回のハイスコアを比較
                if (Score > HighScore)
                {
                    // 現在の大きい場合、ハイスコアを更新
                    HighScore = Score;

                    // ハイスコアを保存
                    SaveHighScore();

                    // ランキングに新しいハイスコアを保存
                    SeveRanking(HighScore);
                }
            }
            // スコアフラグ
            else if(Score == 200)
            {
                HighScore = LoadHighScore();
                if (Score > HighScore)
                {
                    HighScore = Score;
                    SaveHighScore();

                    SeveRanking(HighScore);
                    ComparisonRanking();
                }
            }
            // スコア上限フラグ
            else if (Score == 300)
            {
                HighScore = LoadHighScore();
                if (Score > HighScore)
                {
                    HighScore = Score;
                    SaveHighScore();

                    SeveRanking(HighScore);
                    ComparisonRanking();
                }
            }
            // スコア上限フラグ
            else if (Score == 400)
            {
                HighScore = LoadHighScore();
                if (Score > HighScore)
                {
                    HighScore = Score;
                    SaveHighScore();

                    SeveRanking(HighScore);
                    ComparisonRanking();
                }
            }
            // スコア上限フラグ
            else if (Score == 500)
            {
                HighScore = LoadHighScore();
                if (Score > HighScore)
                {
                    HighScore = Score;
                    SaveHighScore();

                    SeveRanking(HighScore);
                    ComparisonRanking();
                }
            }
            // スコア上限フラグ
            else if (Score >= 600)
            {
                HighScore = LoadHighScore();
                if (Score > HighScore)
                {
                    HighScore = Score;
                    SaveHighScore();

                    SeveRanking(HighScore);
                    ComparisonRanking();
                }
                Score = 0;
            }
        }

        // スコアテキスト更新
        ScoreText.text = "SCORE:  " + Score.ToString() + "\n";
    }

    // デバッグ表示
    void OnGUI()
    {
        float x = Screen.width / 10;
        float y = 150;
        float w = Screen.width * 8 / 10;
        float h = Screen.height / 20;

        // デバッグ表示 現在スコア値の表示
        GUI.Label(new Rect(x, y, w, h), "Score : " + Score);

        // ハイスコアの取得
        HighScore = LoadHighScore();

        // デバッグ ハイスコア値の表示
        GUI.Label(new Rect(x, y + 50, w, h), "HighScore : " + HighScore);

        GUI.Label(new Rect(x, y + 80, w, h), "1. " + ranking[0]);
        GUI.Label(new Rect(x, y + 90, w, h), "2. " + ranking[1]);
        GUI.Label(new Rect(x, y + 100, w, h), "3. " + ranking[2]);
        GUI.Label(new Rect(x, y + 110, w, h), "4. " + ranking[3]);
        GUI.Label(new Rect(x, y + 120, w, h), "5. " + ranking[4]);
    }
}
