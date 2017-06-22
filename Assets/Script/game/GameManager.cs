using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float FadeTime = 1.0f;  //  フェードにかける時間。
    [SerializeField]
    private string FadeSceneName = null;   //  フェードするシーン名

    void Awake()
    {
        float screenRate = (float)512 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);
    }

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("EnemyBoss").Length <= 0)
        {
            if (!FadeManager.GetFadeing())
            {
                FadeManager.Instance.LoadLevel(FadeSceneName, FadeTime);
            }
        }
    }
}
