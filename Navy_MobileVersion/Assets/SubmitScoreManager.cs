using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class SubmitScoreManager : MonoBehaviour
{
    public GameObject SubmitScorePanel;
    public QuestionsBehaviour questionsBehaviour;
    public Text ScoreText;

    public InputField Name;
    public static int ID = 2386;

    void Awake()
    {
        SubmitScorePanel.SetActive(false);
        Name.characterLimit = 6;
    }
    public void SubmitScoreButton()
    {
        SubmitScorePanel.SetActive(true);
        ScoreText.text = $"Score: {questionsBehaviour.Score}";
    }

    void Start()
    {
        Name.characterLimit = 6;
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
    void Update()
    {
        if (Name.text.Length > 6)
        {
            Name.text.Remove(7);
        }
    }
    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(Name.text, int.Parse(questionsBehaviour.Score.ToString()), ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
}
