using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie : MonoBehaviour
{
    [SerializeField]
    private string video = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovieStart()
    {
        Handheld.PlayFullScreenMovie(video, Color.black, FullScreenMovieControlMode.Minimal);
    }
}
