using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwappingVFXSystems : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public ModeSwapper_MasterSystems modeSwapper_MasterSystems;

    private void Start()
    {
        modeSwapper_MasterSystems = GameObject.FindGameObjectWithTag("ModeSwapper").GetComponent<ModeSwapper_MasterSystems>();
    }

    // Update is called once per frame
    void Update()
    {
        Color alpha = spriteRenderer.color;


        if (modeSwapper_MasterSystems.modeNumber == 0)
        {
            alpha.a = 0;
        }

        else if (modeSwapper_MasterSystems.modeNumber == 1)
        {
            alpha.a = 255;
        }

        spriteRenderer.color = alpha;
    }
}
