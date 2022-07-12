using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IDGenerator : MonoBehaviour
{
    [SerializeField]
    private int tagLength = 4;
    private string prevName;

    void Start()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        GetComponent<TMP_InputField>().text = "";
        for (; tagLength > 0; --tagLength)
        {
            GetComponent<TMP_InputField>().text += chars[Random.Range(0, chars.Length)];
        }
        prevName = GetComponent<TMP_InputField>().text;
    }

    public void ExitRename()
    {
        Time.timeScale = 1;
        if (GetComponent<TMP_InputField>().text.Length != 4)
        {
            GetComponent<TMP_InputField>().text = prevName;
        }
        else
        {
            prevName = GetComponent<TMP_InputField>().text;
        }
    }
}
