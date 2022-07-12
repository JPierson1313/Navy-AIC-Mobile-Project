using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwapper_MasterSystems : MonoBehaviour
{
    public GameObject realisticVersionButtonImage;
    public GameObject gamifiedVersionButtonImage;
    public int modeNumber = 0;

    // Update is called once per frame
    void Update()
    {
        switch (modeNumber)
        {
            //Case 2 is used to reset the Mode Number to 0 and switch to Realistic Mode.
            case 2:
                modeNumber = 0;
                break;
        }

        if (modeNumber == 0)
        {
            realisticVersionButtonImage.SetActive(true);
            gamifiedVersionButtonImage.SetActive(false);
        }

        else if (modeNumber == 1)
        {
            realisticVersionButtonImage.SetActive(false);
            gamifiedVersionButtonImage.SetActive(true);
        }
    }

    public void ChangeModeButton()
    {
        modeNumber++;
    }
}
