using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private float FadeTime = 1.0f;  //  フェードにかける時間。
    [SerializeField]
    private string FadeSceneName1 = null;   //  フェードするシーン名
    [SerializeField]
    private string FadeSceneName2 = null;   //  フェードするシーン名

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
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (!FadeManager.GetFadeing())
        //    {
        //        //FadeManager.Instance.LoadLevel(FadeSceneName1, FadeTime);
        //    }
        //}
        //else 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!FadeManager.GetFadeing())
            {
                FadeManager.Instance.LoadLevel(FadeSceneName2, FadeTime);
            }
        }
    }
}
