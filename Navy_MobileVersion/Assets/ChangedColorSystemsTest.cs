using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedColorSystemsTest : MonoBehaviour
{
    [Header("Color System")]
    //[SerializeField, Tooltip("This section will allow you to change the colors for the Ally, Enemy, and Unknown without having to touch any code for it!")]
    [SerializeField] Color friendlyColor;
    [SerializeField] Color unknownColor;
    [SerializeField] Color enemyColor;

    [SerializeField] KeyCode friendlyColorButton;
    [SerializeField] KeyCode unknownColorButton;
    [SerializeField] KeyCode enemyColorButton;

    [SerializeField] GameObject colorTargetSubject;

    // Start is called before the first frame update
    void Start()
    {
        colorTargetSubject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.0f);
            
            if (hit2D.collider)
            {
                Debug.Log("Raycast Hit An Aircraft");
                colorTargetSubject = hit2D.collider.gameObject;
            }
            else
            {
                colorTargetSubject = null;
            }
        }

        if (colorTargetSubject != null)
        {
            if (Input.GetKeyDown(friendlyColorButton))
            {
                colorTargetSubject.GetComponent<SpriteRenderer>().color = friendlyColor;
            }
            else if (Input.GetKeyDown(unknownColorButton))
            {
                colorTargetSubject.GetComponent<SpriteRenderer>().color = unknownColor;
            }
            else if (Input.GetKeyDown(enemyColorButton))
            {
                colorTargetSubject.GetComponent<SpriteRenderer>().color = enemyColor;
            }
        }
    }
}
