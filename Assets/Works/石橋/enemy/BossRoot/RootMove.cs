using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMove : MonoBehaviour
{
    [SerializeField]
    private Root root = null;
    [SerializeField]
    private float speed = 0.0f;

    private int number = 0;

    void Start()
    {

    }
    
    void Update()
    {
        float angle = Mathf.Atan2(root.List[number].transform.position.z - transform.position.z, root.List[number].transform.position.x - transform.position.x);
        transform.position += new Vector3(Mathf.Cos(angle) * speed, 0.0f, Mathf.Sin(angle) * speed);

        if (Vector2.Distance(new Vector2(root.List[number].transform.position.x, root.List[number].transform.position.z), new Vector2(transform.position.x, transform.position.z)) < 0.1f)
        {
            transform.position = root.List[number].transform.position;
            number++;
        }

        if (number >= root.List.Count)
            number = 0;
    }
}
