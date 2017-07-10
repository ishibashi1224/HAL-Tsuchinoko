using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ranking : SingletonMonoBehaviourFast<Ranking>
{
   // [SerializeField]
    private Text RankingText;

    // ランキング表示
    void DrawRanking()
    {
        RankingText.text = "1. " + ((int)ScoreSystem.ranking[0] / 60).ToString(string.Format("00")) + ":" + ((int)ScoreSystem.ranking[0] % 60).ToString(string.Format("00"))
                   +"\n" + "2. " + ((int)ScoreSystem.ranking[1] / 60).ToString(string.Format("00")) + ":" + ((int)ScoreSystem.ranking[1] % 60).ToString(string.Format("00"))
                   +"\n" + "3. " + ((int)ScoreSystem.ranking[2] / 60).ToString(string.Format("00")) + ":" + ((int)ScoreSystem.ranking[2] % 60).ToString(string.Format("00"))
                   +"\n" + "4. " + ((int)ScoreSystem.ranking[3] / 60).ToString(string.Format("00")) + ":" + ((int)ScoreSystem.ranking[3] % 60).ToString(string.Format("00"))
                   +"\n" + "5. " + ((int)ScoreSystem.ranking[4] / 60).ToString(string.Format("00")) + ":" + ((int)ScoreSystem.ranking[4] % 60).ToString(string.Format("00"));
        ;
    }

    // Use this for initialization
    void Start()
    {
        RankingText = gameObject.GetComponent<Text>();

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
        if (ScoreSystem.ranking.Count > 0)
        {
            DrawRanking();
        }
        else if(ScoreSystem.ranking.Count <= 0.0f)
        {
            ScoreSystem.ranking.Clear();
            ScoreSystem.ranking.Add(120);
            ScoreSystem.ranking.Add(180);
            ScoreSystem.ranking.Add(240);
            ScoreSystem.ranking.Add(300);
            ScoreSystem.ranking.Add(360);

            DrawRanking();
        }
    }
}
