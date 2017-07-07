using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    private GameObject camera = null;
    [SerializeField]
    private float move = 0;
    [SerializeField]
    private float speed = 0;

    private float posx;
    private static bool use;

    // Use this for initialization
    void Start()
    {
        use = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (use)
        {
            camera.transform.position = Vector3.Lerp(new Vector3(posx, camera.transform.position.y, 0), new Vector3(camera.transform.position.x, camera.transform.position.y, 0), speed);
            if(posx - 0.01f <= camera.transform.position.x && posx + 0.01f >= camera.transform.position.x)
            {
                camera.transform.position = new Vector3(posx, camera.transform.position.y, 0);
                use = false;
            }
        }
    }

    public void RightScroll()
    {
        if (!use && move >= camera.transform.position.x + move)
        {
            posx = camera.transform.position.x + move;
            use = true;
        }
    }

    public void LeftScroll()
    {
        if (!use && -move <= camera.transform.position.x - move)
        {
            posx = camera.transform.position.x - move;
            use = true;
        }
    }

    public static bool GetUse()
    {
        return use;
    }
}
