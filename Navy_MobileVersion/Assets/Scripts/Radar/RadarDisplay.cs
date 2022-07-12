using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// Takes info of targets selected using the LMB & RMB and displays them on a HUD
/// </summary>
public class RadarDisplay : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("Object at the center of the radar; must have a Rigidbody2D")]
    private GameObject player;
    [Tooltip("Camera that is rendering the radar screen")]
    private Camera radarCamera;

    [Header("HUD")]
    [SerializeField, Tooltip("Text box that displays info about target aircraft")]
    private GameObject HUDTargetInfo;
    [SerializeField, Tooltip("Text box that displays info about target aircraft")]
    private GameObject HUDTargetInfo2;

    [Header("Targets")]
    [SerializeField, Tooltip("Aircraft whose velocity & positon are displayed on the radar; must have a Rigidbody2D")]
    private GameObject target;

    //Jarretts Added Code --------------------------------------------
    public TMP_Text targetID;
    public TMP_InputField targetID_InputField;
    //----------------------------------------------------------------

    [SerializeField, Tooltip("Aircraft whose velocity & positon are displayed on the radar; must have a Rigidbody2D")]
    private GameObject target2;

    public GameObject HVT;

    //Jarretts Added Code --------------------------------------------
    public TMP_Text target2ID;
    public TMP_InputField target2ID_InputField;
    //----------------------------------------------------------------

    [Space]
    [SerializeField, Tooltip("Reference to Target Highlight prefab")]
    private GameObject targetHighlightPrefab;
    [Tooltip("UI Icon for highlighting GameObject target")]
    private GameObject targetHighlight;
    [Tooltip("UI Icon for highlighting GameObject target2")]
    private GameObject targetHighlight2;

    [Header("Color System")]
    [SerializeField, Tooltip("Color for friendly entities")]
    Color friendlyColor = new Color(0, 255, 255);
    [SerializeField, Tooltip("Color for unknown entities")]
    Color unknownColor = new Color(255, 190, 0);
    [SerializeField, Tooltip("Color for hostile entities")]
    Color enemyColor = new Color(255, 0, 0);

    [SerializeField, Tooltip("Keycode for coloring primary target as friendly")]
    KeyCode friendlyColorButton = KeyCode.Alpha1;
    [SerializeField, Tooltip("Keycode for coloring primary target as unknown")]
    KeyCode unknownColorButton = KeyCode.Alpha2;
    [SerializeField, Tooltip("Keycode for coloring primary target as hostile")]
    KeyCode enemyColorButton = KeyCode.Alpha3;

    // Touch Controls
    private Touch touch;
    private float holdTime;
    [SerializeField]
    private float maxHoldTime = 0.8f;

    EventSystem eventSystem;

    TouchScreenKeyboard keyboard;
    #endregion

    private void Awake()
    {
        #region Define If Null
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (HUDTargetInfo == null)
        {
            HUDTargetInfo = GameObject.Find("Target Info 1 (TMP)");
        }
        //if (HUDTargetInfo2 == null)
        //{
        //	HUDTargetInfo2 = GameObject.Find("Target Info 2 (TMP)");
        //}
        #endregion

#if UNITY_EDITOR
        // Check that variables are assigned and have required components
        #region Check Variables
        if (player == null)
        {
            Debug.LogError("Variable player in RadarDisplay.cs is not assigned");
        }
        if (player.GetComponent<Rigidbody2D>() == null)
        {
            Debug.LogError("Player does not have Rigidbody2D");
        }
        if (HUDTargetInfo == null)
        {
            Debug.LogError("Variable HUDTargetInfo in RadarDisplay.cs is not assigned");
        }
        if (HUDTargetInfo.GetComponent<TextMeshProUGUI>() == null)
        {
            Debug.LogError("HUDTargetInfo does not have TextMeshProUGUI");
        }
        #endregion
#endif

        targetHighlight = Instantiate(targetHighlightPrefab, new Vector2(9999, 9999), Quaternion.Euler(0, 0, 0),
            GameObject.FindGameObjectWithTag("Canvas").transform.Find("Mask"));
        targetHighlight2 = Instantiate(targetHighlightPrefab, new Vector2(9999, 9999), Quaternion.Euler(0, 0, 0),
            GameObject.FindGameObjectWithTag("Canvas").transform.Find("Mask"));
        radarCamera = GameObject.Find("Radar Camera").GetComponent<Camera>();

        eventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
        Vector2 radarCenter = new Vector2(0.715f, 0.5f);
        if (Vector2.Distance(mousePos, radarCenter) < 0.475f && Mathf.Abs(radarCenter.x - mousePos.x) < 0.27f) // Check that raycast is inside the radar
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckForTarget(1);
            }
            if (Input.GetMouseButtonDown(1))
            {
                CheckForTarget(2);
            }
        }

        // Touch Input
        if(!Camera.main.GetComponent<CameraMovement>().isMoving)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            {
                holdTime = 0;
            }
            else if (Input.GetMouseButton(0))
            {
                holdTime += Time.unscaledDeltaTime;
            }

            if (holdTime >= maxHoldTime)
            {
                CheckForTarget(2);
            }
        }
        else
        {
            holdTime = 0;
        }

        GetTargetInfo();
        DrawRadarLine();

        if (Input.GetKeyDown(friendlyColorButton))
        { ColorTarget(0); }
        if (Input.GetKeyDown(unknownColorButton))
        { ColorTarget(1); }
        if (Input.GetKeyDown(enemyColorButton))
        { ColorTarget(2); }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RenameTarget();
        }
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && target.transform.GetChild(1).GetComponent<TMP_InputField>().IsActive())
        {
            if (target != null)
            {
                target.transform.GetChild(1).GetComponent<IDGenerator>().ExitRename();
                if (TouchScreenKeyboard.visible == false && keyboard != null)
                {
                    if (keyboard.done)
                    {
                        keyboard = null;
                    }
                }
            }
        }
    }

    // Check for target where the mouse is
    private void CheckForTarget(int targetIndex)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(radarCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.0f);
        if (hit2D.transform == null)
        {
            switch (targetIndex)
            {
                case 1:
                    target = null;
                    targetHighlight.SetActive(false);
                    break;
                case 2:
                    target2 = null;
                    targetHighlight2.SetActive(false);
                    break;
            }
        }
        else
        {
            switch (targetIndex)
            {
                case 1:
                    if (hit2D.collider.gameObject != player)
                    {
                        target = hit2D.collider.gameObject;
                        targetHighlight.SetActive(true);
                        if (hit2D.collider.gameObject == target2)
                        {
                            target2 = null;
                        }
                    }
                    break;
                case 2:
                    if (hit2D.collider.gameObject != player)
                    {
                        target2 = hit2D.collider.gameObject;
                        targetHighlight2.SetActive(true);
                        if (hit2D.collider.gameObject == target)
                        {
                            target = null;
                        }
                    }
                    break;
            }
        }

    }

    // Calculate velocity & position of target aircraft, and display it on HUDTargetInfo
    private void GetTargetInfo()
    {
        if (target != null && HUDTargetInfo != null)
        {
            // Update info on HUD
            EntityInfo targetInfo = target.GetComponent<EntityInfo>();
            float range;
            float angle;
            if (target2 != null)
            {
                range = Vector3.Distance(target2.transform.position, target.transform.position);
                Vector2 targetDirection = (target2.transform.position - target.transform.position).normalized;
                angle = -Vector2.SignedAngle(targetInfo.direction, targetDirection);
                if (angle < 0)
                {
                    angle += 360;
                }
            }
            else
            {
                range = Vector3.Distance(HVT.transform.position, target.transform.position);
                Vector2 targetDirection = (HVT.transform.position - target.transform.position).normalized;
                angle = -Vector2.SignedAngle(targetInfo.direction, targetDirection);
                if (angle < 0)
                {
                    angle += 360;
                }
            }
            HUDTargetInfo.GetComponent<TextMeshProUGUI>().text =
                string.Format("ID: {0}\nSpeed: {1:N}kts\nBearing: {2:F}°\nElevation: {3:N0}ft\nRange: {4:F}NM\n",
                target.transform.GetChild(1).GetComponent<TMP_InputField>().text, targetInfo.velocity, angle, targetInfo.elevation, range * 5.2f);

            // Highlight Target
            targetHighlight.transform.position = radarCamera.WorldToScreenPoint(target.transform.position);
        }
        else
        {
            // Update info on HUD
            HUDTargetInfo.GetComponent<TextMeshProUGUI>().text =
                string.Format("ID: \nSpeed: \nBearing: \nElevation: \nRange: \n");

            targetHighlight.SetActive(false);
        }

        if (target2 != null && HUDTargetInfo2 != null)
        {
            // TODO: Make numbers more "realistic"
            EntityInfo targetInfo = target2.GetComponent<EntityInfo>();
            Vector2 relativePosition = Vector2.zero;
            float range;
            float angle;
            if (target != null)
            {
                relativePosition = target.GetComponent<EntityInfo>().position - target2.GetComponent<EntityInfo>().position;
                range = Vector3.Distance(target2.transform.position, target.transform.position);
                Vector2 targetDirection = (target.transform.position - target2.transform.position).normalized;
                angle = -Vector2.SignedAngle(targetInfo.direction, targetDirection);
                if (angle < 0)
                {
                    angle += 360;
                }
            }
            else
            {
                relativePosition = target2.GetComponent<EntityInfo>().position;
                range = Vector3.Distance(HVT.transform.position, target2.transform.position);
                Vector2 targetDirection = (HVT.transform.position - target2.transform.position).normalized;
                angle = -Vector2.SignedAngle(targetInfo.direction, targetDirection);
                if (angle < 0)
                {
                    angle += 360;
                }
            }

            // Update info on HUD
            HUDTargetInfo2.GetComponent<TextMeshProUGUI>().text =
                string.Format("ID: {0}\nSpeed: {1:N}kts\nBearing: {2:F}°\nElevation: {3:N0}ft\nRange: {4:F}NM\n",
                target2.transform.GetChild(1).GetComponent<TMP_InputField>().text, targetInfo.velocity, angle, targetInfo.elevation, range * 5.2f);

            // Highlight Target
            targetHighlight2.transform.position = radarCamera.WorldToScreenPoint(target2.transform.position);
        }
        else
        {
            // Update info on HUD
            HUDTargetInfo2.GetComponent<TextMeshProUGUI>().text =
                string.Format("ID: \nSpeed: \nBearing: \nElevation: \nRange:");

            targetHighlight2.SetActive(false);
        }
    }

    private void DrawRadarLine()
    {
        LineRenderer lr = GetComponent<LineRenderer>();

        if (target != null && target2 != null)
        {
            lr.SetPosition(0, target.transform.position);
            lr.SetPosition(1, target2.transform.position);
        }
        else
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position);
        }
    }

    private void ColorTarget(int color)
    {
        switch (color)
        {
            case 0:
                target.GetComponent<SpriteRenderer>().color = friendlyColor;
                break;
            case 1:
                target.GetComponent<SpriteRenderer>().color = unknownColor;
                break;
            case 2:
                target.GetComponent<SpriteRenderer>().color = enemyColor;
                break;
        }
    }

    public void RenameTarget(int targetIndex = 1)
    {
        if (targetIndex == 1)
        {
            if (target != null && Time.timeScale >= 0.1f)
            {
                Time.timeScale = 0;
                TMP_InputField inputField = target.transform.GetChild(1).GetComponent<TMP_InputField>();
                keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
                inputField.ActivateInputField();
            }
        }
        else if (targetIndex == 2)
        {
            if (target2 != null && Time.timeScale >= 0.1f)
            {
                Time.timeScale = 0;
                TMP_InputField inputField = target2.transform.GetChild(1).GetComponent<TMP_InputField>();
                keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
                inputField.ActivateInputField();
            }
        }
    }
}
