using UnityEngine;
using System.Collections;
using UnityEngine.UI;     //UIを使用可能にする
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FadeManager : SingletonMonoBehaviourFast<FadeManager>
{
    //  フェード中の透明度
    private float fadeAlpha = 0;
    //  フェード中かどうか
    private static bool isFading = false;
    //  フェードの色。
    public Color fadeColor = Color.black;

    public void Start()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    //  フェード描画。
    public void OnGUI()
    {
        if (isFading)
        {
            //  透明度を更新して黒テクスチャを描画
            this.fadeColor.a = this.fadeAlpha;
            GUI.color = this.fadeColor;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
    }

    //  画面遷移 scene = シーン名, interval = 暗転にかかる時間(秒)
    public void LoadLevel(string scene, float interval)
    {
        StartCoroutine(TransScene(scene, interval));
    }

    //  シーン遷移用コルーチン     scene = シーン名, interval = 暗転にかかる時間(秒)
    private IEnumerator TransScene(string scene, float interval)
    {
        //  だんだん暗く
        isFading = true;
        float time = 0;
        while (time <= interval)
        {
            this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        //  シーン切替
        SceneManager.LoadScene(scene);

        //  だんだん明るく
        time = 0;
        while (time <= interval)
        {
            this.fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        isFading = false;
    }

    public static bool GetFadeing()
    {
        return isFading;
    }
}

