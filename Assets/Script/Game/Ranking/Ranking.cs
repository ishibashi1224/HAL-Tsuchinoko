using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    private Text RankingText = null;

    // ランキング表示
    void DrawRanking()
    {
        RankingText.text = "1." + ScoreSystem.ranking[0] + "\n" + "2." + ScoreSystem.ranking[1] + "\n" + "3." + ScoreSystem.ranking[2] + "\n" + "4." + ScoreSystem.ranking[3] + "\n" + "5." + ScoreSystem.ranking[4] + "\n";
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DrawRanking();
    }
}
