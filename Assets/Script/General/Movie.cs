using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movie : MonoBehaviour
{ 
    [SerializeField]
    MovieTexture m_movieTexture = null;

    public void Play()
    {
        m_movieTexture.Play();
    }

    public void Stop()
    {
        m_movieTexture.Pause();
    }

    public void RePlay()
    {
        m_movieTexture.Stop();
        m_movieTexture.Play();
    }

    void Start()
    {
        m_movieTexture.loop = false;
        gameObject.GetComponent<Renderer>().material.mainTexture = m_movieTexture;
    }
}
