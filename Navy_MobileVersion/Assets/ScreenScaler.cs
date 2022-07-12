using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScaler : MonoBehaviour
{
    public SpriteRenderer screen;

    // Use this for initialization
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = screen.bounds.size.x / screen.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = screen.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = screen.bounds.size.y / 2 * differenceInSize;
        }
    }
}
