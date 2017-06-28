using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject On;
    [SerializeField]
    private GameObject Off;

    private Canvas canvas;
    private static string SceneName;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
       
        SceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        On.SetActive(true);
        Off.SetActive(false);
    }

    public void OnOff()
    {
        if (!FadeManager.GetFadeing())
        {
            canvas.enabled = !canvas.enabled;
            Pause();
            Switching();
            AudioManager.Instance.PlaySE("se6");
        }
    }

    public void Switching()
    {
        On.SetActive(!On.activeSelf);
        Off.SetActive(!Off.activeSelf);
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Continue()
    {
		if (!FadeManager.GetFadeing ()) 
		{
			canvas.enabled = !canvas.enabled;
            Switching();
            Time.timeScale = 1;
			AudioManager.Instance.PlaySE ("se6");
		}
    }

    public void MainMenu()
    {
		if (!FadeManager.GetFadeing ()) 
		{
			Time.timeScale = 1;
			FadeManager.Instance.LoadLevel ("Menu", 1);
			AudioManager.Instance.PlaySE ("se6");
		}
    }

    public void Retry()
    {
		if (!FadeManager.GetFadeing ()) 
		{
            Time.timeScale = 1;
			FadeManager.Instance.LoadLevel ("Game", 1);
			AudioManager.Instance.PlaySE ("se6");
		}
    }

    public static string GetSceneName()
    {
        return SceneName;
    }
}
