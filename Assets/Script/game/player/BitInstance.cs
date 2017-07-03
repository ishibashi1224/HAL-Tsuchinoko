using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BitInstance : MonoBehaviour {

    private int bitNum = 3;
    private GameObject[] bit = new GameObject[3];

    [SerializeField]
    private GameObject bulletManager;

    [SerializeField]
    private List<GameObject> bitType;

    //ファイル読み込み用
    private TextAsset textFile;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void bitForm()
    {
        //ビットの付け替えファイル読み込み
        textFile = Resources.Load("BitData/PlayerBitData") as TextAsset;
        StringReader reader = new StringReader(textFile.text);

        for (int i = 0; i < bitNum; i++)
        {
            //ビット番号受け取る
            bit[i] = bitType[ int.Parse( reader.ReadLine() ) ];

            //ビット生成
            Instantiate(bit[i], transform.position, transform.rotation).transform.parent = transform;
            transform.GetChild(i + 1).SetSiblingIndex(transform.GetChild(i + 1).GetSiblingIndex() - 1);
            transform.GetChild(i).transform.GetComponent<BulletManager>().magazine = bulletManager.transform.GetChild(i).gameObject;
            transform.GetChild(i).transform.localScale = new Vector3(3.0f, 1.0f, 3.0f);
        }
        reader.Close();
    }
}
