using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwappingSystems : MonoBehaviour
{
    [Tooltip("Military icon as seen on radar displays")] 
    public Sprite realisticVersionSprite;

    //[Tooltip("Military icon for enemy aircraft")]
    //public Sprite realisticVersionEnemySprite;

    [Tooltip("Aircraft or other vehicle/building icon")]
    public Sprite gamifiedVersionSprite;

    public SpriteRenderer spriteRenderer;
    private LineRenderer lineRenderer;
    private AutoAnimate autoAnimate;

    public ModeSwapper_MasterSystems modeSwapper_MasterSystems;

    //On Start, we set spriteRenderer to the SpriteRenderer Component attached to the Gameobject and repeat the same process for lineRenderer with LineRenderer.
    void Start()
    {
        modeSwapper_MasterSystems = GameObject.FindGameObjectWithTag("ModeSwapper").GetComponent<ModeSwapper_MasterSystems>();
        //Player is a tag set for the CAP Building as it does not need to use a line renderer nor auto animate scripts
        if (gameObject.tag != "Player")
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            autoAnimate = GetComponent<AutoAnimate>();
        }
    }

    void Update()
    {
        if (modeSwapper_MasterSystems.modeNumber == 0)
        {
            spriteRenderer.sprite = realisticVersionSprite;
            if (gameObject.tag != "Player")
            {
                lineRenderer.enabled = true;
                autoAnimate.setRotation = false;
                spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        else if (modeSwapper_MasterSystems.modeNumber == 1)
        {
            spriteRenderer.sprite = gamifiedVersionSprite;
            if (gameObject.tag != "Player")
            {
                lineRenderer.enabled = false;
                autoAnimate.setRotation = true;
            }
        }
    }

    //Method used to change the sprite of a half circle icon(bogey) to a half diamond icon(enemy) as well as changing the color of the enemy to red instead of orange.
    //I created and used the Resources Folder to load in the Enemy Icon sprite instead of a field since we will have friendly aircraft and did not want to have an unused field for them.
    public void EnemyAircraftIdentified()
    {
        if (this.gameObject.tag == "Enemy")
        {
            realisticVersionSprite = Resources.Load<Sprite>("Enemy_Icon");
            spriteRenderer.color = Color.red;
        }
    }
}
