using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{
    private Canvas canvas;
    private static string SceneName;

    void Start()
    {
        canvas = GetComponent<Canvas>();
       
        SceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    void Update()
    {
		if (!FadeManager.GetFadeing())
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                canvas.enabled = !canvas.enabled;
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Resume()
    {
		if (!FadeManager.GetFadeing ()) 
		{
			canvas.enabled = !canvas.enabled;
			Time.timeScale = 1;
			AudioManager.Instance.PlaySE ("se6");
		}
    }

    public void Redo()
    {
		if (!FadeManager.GetFadeing ())
		{
			Time.timeScale = 1;
			FadeManager.Instance.LoadLevel (SceneName, 1);
			AudioManager.Instance.PlaySE ("se6");
		}
    }

    public void MenuReturn()
    {
		if (!FadeManager.GetFadeing ()) 
		{
			Time.timeScale = 1;
			FadeManager.Instance.LoadLevel ("menu", 1);
			AudioManager.Instance.PlaySE ("se6");
		}
    }

    public void TitleReturn()
    {
		if (!FadeManager.GetFadeing ()) 
		{
			Time.timeScale = 1;
			FadeManager.Instance.LoadLevel ("title", 1);
			AudioManager.Instance.PlaySE ("se6");
		}
    }

    public static string GetSceneName()
    {
        return SceneName;
    }
}
