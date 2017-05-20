using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour
{
    [SerializeField]
    private float interval = 0.0f;
    private float time = 0.0f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= interval)
        {
            Destroy(gameObject);
        }
        time += Time.deltaTime;
    }
}
