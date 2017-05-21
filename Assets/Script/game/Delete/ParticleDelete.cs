using UnityEngine;
using System.Collections;

public class ParticleDelete : MonoBehaviour
{
    ParticleSystem Particle = null;
    // Use this for initialization
    void Start()
    {
        Particle = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Particle != null)
        {
            if (!Particle.IsAlive())
            {
                Destroy(Particle.gameObject);
            }
        }
    }
}
