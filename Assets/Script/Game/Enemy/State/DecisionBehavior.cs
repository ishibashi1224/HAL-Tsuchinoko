using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionBehavior : MonoBehaviour
{
    [SerializeField]
    private List<EnemyBehavior> enemyBehaviorList = null;
    [SerializeField]
    private TextAsset File = null; // CSVファイル
    [SerializeField]
    private List<string[]> Data = new List<string[]>(); // CSVの中身を入れるリスト

    //読み込めたか確認の表示用の変数
    private int height = 0;    //行数

    void Awake()
    {
        StringReader reader = new StringReader(File.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            Data.Add(line.Split(',')); // リストに入れる
            height++; // 行数加算
        }
    }

    public EnemyBehavior Decision(EnemyBehavior enemyBehavior)
    {
        if(enemyBehavior == null)
        {
            return enemyBehaviorList[UnityEngine.Random.Range(0, enemyBehaviorList.Count)];
        }

        for(int count = 0; count < enemyBehaviorList.Count; count++)
        {
            if(enemyBehaviorList[count] == enemyBehavior)
            {
                int num = UnityEngine.Random.Range(0, 100);
                int probability = 0;
                int oldProbability = 0;
                for (int _count = 0; _count < Data[count].Length; _count++)
                {
                    oldProbability = probability;
                    probability += int.Parse(Data[count][_count]);

                    if(oldProbability < num  && num < probability)
                    {
                        return enemyBehaviorList[_count];
                    }
                }
            }
        }

        return null;
    }
}
