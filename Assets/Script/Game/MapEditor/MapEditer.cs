﻿using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditer : MonoBehaviour
{ 
    [SerializeField]
    //private GameObject FieldObject;

    List<GameObject> FieldPrefabs = new List<GameObject>();

    [SerializeField]
    private float fPosx = 0.0f;

    [SerializeField]
    private float fPosy = 0.0f;

    [SerializeField]
    private float fPosz = 0.0f;

    [SerializeField]
    private float fSpacingDistansX = 0.0f;

    [SerializeField]
    private float fSpacingDistansZ = 0.0f;

    [SerializeField]
    private float fFog = 0.0f;

    [SerializeField]
    private TextAsset csvFileMap; // CSVファイル

    [SerializeField]
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト

    // 敵データ格納用の配列データ(とりあえず初期値はnull値)
    private int[,] stageMapDatas;

    // CSVから切り分けられた文字列型２次元配列データ 
    private string[,] sdataArrays;

    //読み込めたか確認の表示用の変数
    private int height = 0;    //行数
    private int width = 0;     //列数

    private void readCSVData(string path, ref string[,] sdata)
    {
        // ストリームリーダーsrに読み込む
        StreamReader sr = new StreamReader(path);

        // ストリームリーダーをstringに変換
        string strStream = sr.ReadToEnd();

        // StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
        System.StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

        // 行に分ける
        string[] lines = strStream.Split(new char[] { '\r', '\n' }, option);

        // カンマ分けの準備(区分けする文字を設定する)
        char[] spliter = new char[1] { ',' };

        // 行数設定
        int heightLength = lines.Length;
        // 列数設定
        int widthLength = lines[0].Split(spliter, option).Length;

        // 返り値の2次元配列の要素数を設定
        sdata = new string[heightLength, widthLength];

        // 行データを切り分けて,2次元配列へ変換する
        for (int i = 0; i < heightLength; i++)
        {
            string[] splitedData = lines[i].Split(spliter, option);

            for (int j = 0; j < widthLength; j++)
            {
                sdata[i, j] = splitedData[j];
            }
        }

        // 確認表示用の変数(行数、列数)を格納する
        this.height = heightLength;    //行数   
        this.width = widthLength;    //列数
    }

    // ２次元配列の型を文字列型から整数値型へ変換する
    private void convert2DArrayType(ref string[,] sarrays, ref int[,] iarrays, int h, int w)
    {
        iarrays = new int[h, w];
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                iarrays[i, j] = int.Parse(sarrays[i, j]);
                SetObject(j, i, int.Parse(sarrays[i, j]));
            }
        }
    }

    //確認表示用の関数
    //引数：2次元配列データ,行数,列数
    private void WriteMapDatas(int[,] arrays, int hgt, int wid)
    {
        for (int i = 0; i < hgt; i++)
        {

            for (int j = 0; j < wid; j++)
            {
                //行番号-列番号:データ値 と表示される
                Debug.Log(i + "-" + j + ":" + arrays[i, j]);
            }
        }
    }

    private void SetObject(int x, int z, int Number )
    {
        Debug.Log(Number);

        if (Number != 0 && Number <= FieldPrefabs.Count)
        {
            Instantiate(FieldPrefabs[Number - 1], new Vector3(x * fSpacingDistansX + fPosx, FieldPrefabs[Number - 1].transform.position.y + fPosy, -z * fSpacingDistansZ - fPosz), Quaternion.identity);
        }

    }

    private void RenderSetting()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = Color.black;
        RenderSettings.fogDensity = 0f;
    }

    void Start()
    {
        /* New ver */
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // csvFileMap = Resources.Load(csvDatas.Count) as TextAsset; /* Resouces/CSV下のCSV読み込み */

        // インスペクター上でcsvFileMapに入れたCSVファイルの生成
        StringReader reader = new StringReader(csvFileMap.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる
            height++; // 行数加算
        }

        for( int nHeight = 0; nHeight < height; nHeight++ )
        {
            for (int nWidth = 0; nWidth < csvDatas[nHeight].Length; nWidth++)
            {
                SetObject(-height / 2 + nWidth, -height / 2 + nHeight, int.Parse(csvDatas[nHeight][nWidth]));
            }
        }

        // レンダー設定
        RenderSetting();

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }

    void UpDate()
    {
        if(RenderSettings.fogDensity < fFog)
        {
            RenderSettings.fogDensity += 0.01f;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(fFog);

        if (collider.gameObject.name.StartsWith("Cube"))
        {
            fFog += 0.05f;
        }
    }
}
