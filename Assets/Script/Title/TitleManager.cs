using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : SingletonMonoBehaviourFast<TitleManager>
{
    [SerializeField]
    private float FadeTime = 1.0f;  //  フェードにかける時間。
    [SerializeField]
    private string FadeSceneName = null;   //  フェードするシーン名

    // Use this for initialization
    void Start()
    {
        float screenRate = (float)380 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);
        AudioManager.Instance.PlayBGM("title", true);
    }

    public void Scene()
    {
        if (!FadeManager.GetFadeing())
        {
            FadeManager.Instance.LoadLevel(FadeSceneName, FadeTime);
        }
    }
}
