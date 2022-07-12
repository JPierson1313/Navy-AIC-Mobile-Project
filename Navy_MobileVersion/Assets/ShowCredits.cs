using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    public GameObject creditsCanvas;

    void Awake()
    {
        creditsCanvas.SetActive(false);
    }

    public void OpenCreditsButton()
    {
        creditsCanvas.SetActive(true);
    }

    public void CloseCreditsButton()
    {
        creditsCanvas.SetActive(false);
    }
}
