using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet = null;

    [SerializeField]
    private GameObject magazine = null;

    [SerializeField]
    private float interval = 0.0f;
    private float time = 0.0f;
    private Quaternion tes;

    [SerializeField]
    private int BulletLimit = 20;

    private int childCnt = 0;

    // Use this for initialization
    void Start()
    {
        for( int i = 0; i < BulletLimit; i++ )
        {
            Instantiate(bullet, transform.position, transform.rotation ).transform.parent = magazine.transform;
            magazine.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bulletTrueFalse() == true && ArtsTrueFalse() == false)
        { 
            if (time >= interval)
            {
                childCnt++;
                tes = Quaternion.identity;
                tes.y = 90;

                if (childCnt >= BulletLimit)
                {
                    childCnt = 0;
                }

                //Instantiate(bullet, transform.position, transform.rotation * transform.localRotation).transform.parent = transform;
                if (magazine.transform.GetChild(childCnt).gameObject.activeSelf == false)
                {
                    magazine.transform.GetChild(childCnt).gameObject.SetActive(true);
                    magazine.transform.GetChild(childCnt).gameObject.transform.position = transform.position;
                    magazine.transform.GetChild(childCnt).gameObject.transform.rotation = transform.rotation * transform.localRotation;
                }

                time = 0;
            }
            time += Time.deltaTime;
        }
    }

    bool bulletTrueFalse()
    {
        if (transform.GetChild(0).gameObject.GetComponent<BitLife>().lifeTrueFalse() == true)
        {
            return true;
        };
        return false;
    }

    bool ArtsTrueFalse()
    {
        if( transform.root.gameObject.transform.GetChild(3).gameObject.activeSelf == true )
        {
            return true;
        }
        return false;
    }
}
