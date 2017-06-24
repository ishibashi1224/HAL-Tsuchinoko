using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapInput : SingletonMonoBehaviourFast<TapInput>
{
    private GUIStyle labelStyle;
    private Vector2 currentScreenPoint;
    private Vector3 currentPosition;
    private string Direction;

    [SerializeField]
    private float rate;

    [SerializeField]
    private Vector2 position;

    // Use this for initialization
    void Start () {
        //フォント生成
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;

        currentScreenPoint = new Vector2(Input.mousePosition.x , Input.mousePosition.y);
        currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);

            if (currentScreenPoint.x< Screen.width * rate)
            {
                bool hit = true;
            }
        }
    }

    void OnGUI()
    {
        float x = Screen.width / 10;
        float y = 0;
        float w = Screen.width * 8 / 10;
        float h = Screen.height / 20;

        string text = string.Empty;

        text = currentScreenPoint.x.ToString();
        GUI.Label(new Rect(x, y, w, h), text, this.labelStyle);

        text = currentScreenPoint.y.ToString();
        GUI.Label(new Rect(x+w*0.25f, y, w, h), text, this.labelStyle);

        text = Screen.width.ToString();
        GUI.Label(new Rect(x, y+ h * 0.5f, w, h), text, this.labelStyle);

        text = Screen.height.ToString();
        GUI.Label(new Rect(x, y + h * 1.0f, w, h), text, this.labelStyle);
    }

    public string GetDirection ()
    {
        return Direction;
    }
}
