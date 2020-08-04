using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StopVideos : MonoBehaviour
{
    public RACanvasControl[] videos;

    public void SetCurrentVideo(General.EnumMovies current)
    {
        for (int i = 0; i < (int)General.EnumMovies.MAX_MOVIES; i++)
        {
            if (i != (int)current)
            {   
                videos[i].StopTrailer();
            }
        }
    }
}
