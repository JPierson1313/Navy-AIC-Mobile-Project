using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenarioOneQuestions : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI AnswerOneText;
    public TextMeshProUGUI AnswerTwoText;
    public TextMeshProUGUI AnswerThreeText;
    public TextMeshProUGUI AnswerFourText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI FinalScoreText;
    public TextMeshProUGUI FinalFlavorText;

    public GameObject QuestionContainer;
    public GameObject PostGameReviewContainer;

    private int OptionOneScoreValue;
    private int OptionTwoScoreValue;
    private int OptionThreeScoreValue;
    private int OptionFourScoreValue;
    public int Score;
    public float QuestionNumber = 1;

    private float timer;
    private int IntTimer;

    public FileReader fileReader;

    private int green = 1000;
    private int yellow = 500;
    private int purple = 50;
    private int red = -500;

    void Awake()
    {
        PostGameReviewContainer.SetActive(false);
        QuestionContainer.SetActive(true);
    }

    public void Update()
    {
        Debug.Log($"Score: {Score}");
        
        switch(QuestionNumber)
        {
            case 1 : Question1();
                QuestionNumber += .1f;
                break;
            case 2 : Question2();
                QuestionNumber += .1f;
                break;
            case 3 : Question3();
                QuestionNumber += .1f;
                break;
            case 4 : Question4();
                QuestionNumber += .1f;
                break;
            case 5 : Question5();
                QuestionNumber += .1f;
                break;
            case 6 : Question6();
                QuestionNumber += .1f;
                break;
            case 7 : PostGameReview();
                break;
        }

        timer += Time.deltaTime;
        IntTimer = Mathf.FloorToInt(timer);
        TimerText.text = IntTimer.ToString();
        ScoreText.text = $"Score: {Score}";

        if(timer >= 8)
        {
            TimerText.color = Color.yellow;
        }

        if(timer >= 12)
        {
            TimerText.color = Color.red;
        }

        if(timer >= 15)
        {
            CancelInvoke("TimerAffectsScore");
            Score += red;
            QuestionNumber += .9f;
            timer = 0;
            IntTimer = 0;
            TimerText.color = Color.white;
        }
    }


    public void Button1()
    {
        CancelInvoke("TimerAffectsScore");
        Score += OptionOneScoreValue;
        ResetTimer();
    }

    public void Button2()
    {
        CancelInvoke("TimerAffectsScore");
        Score += OptionTwoScoreValue;
        ResetTimer();
    }

    public void Button3()
    {
        CancelInvoke("TimerAffectsScore");
        Score += OptionThreeScoreValue;
        ResetTimer();
    }

    public void Button4()
    {
        CancelInvoke("TimerAffectsScore");
        Score += OptionFourScoreValue;
        ResetTimer();
    }

    void ResetTimer()
    {
        QuestionNumber += .9f;
        timer = 0;
        IntTimer = 0;
        TimerText.color = Color.white;
    }

    public void Question1()
    {
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        QuestionText.text = fileReader.myScenarioList.scenarioOne[0].Question.ToString();
        
        AnswerOneText.text = fileReader.myScenarioList.scenarioOne[0].OptionOne.ToString();
        OptionOneScoreValue = red;
        AnswerTwoText.text = fileReader.myScenarioList.scenarioOne[0].OptionTwo.ToString();
        OptionTwoScoreValue = green;
        AnswerThreeText.text = fileReader.myScenarioList.scenarioOne[0].OptionThree.ToString();
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = fileReader.myScenarioList.scenarioOne[0].OptionFour.ToString();
        OptionFourScoreValue = purple;
    }

    public void Question2()
    {
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        QuestionText.text = fileReader.myScenarioList.scenarioOne[1].Question.ToString();
        
        AnswerOneText.text = fileReader.myScenarioList.scenarioOne[1].OptionOne.ToString();
        OptionOneScoreValue = red;
        AnswerTwoText.text = fileReader.myScenarioList.scenarioOne[1].OptionTwo.ToString();
        OptionTwoScoreValue = green;
        AnswerThreeText.text = fileReader.myScenarioList.scenarioOne[1].OptionThree.ToString();
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = fileReader.myScenarioList.scenarioOne[1].OptionFour.ToString();
        OptionFourScoreValue = purple;
    }

    public void Question3()
    {
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        QuestionText.text = fileReader.myScenarioList.scenarioOne[2].Question.ToString();
        
        AnswerOneText.text = fileReader.myScenarioList.scenarioOne[2].OptionOne.ToString();
        OptionOneScoreValue = red;
        AnswerTwoText.text = fileReader.myScenarioList.scenarioOne[2].OptionTwo.ToString();
        OptionTwoScoreValue = green;
        AnswerThreeText.text = fileReader.myScenarioList.scenarioOne[2].OptionThree.ToString();
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = fileReader.myScenarioList.scenarioOne[2].OptionFour.ToString();
        OptionFourScoreValue = purple;
    }

    public void Question4()
    {
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        QuestionText.text = fileReader.myScenarioList.scenarioOne[3].Question.ToString();
        
        AnswerOneText.text = fileReader.myScenarioList.scenarioOne[3].OptionOne.ToString();
        OptionOneScoreValue = red;
        AnswerTwoText.text = fileReader.myScenarioList.scenarioOne[3].OptionTwo.ToString();
        OptionTwoScoreValue = green;
        AnswerThreeText.text = fileReader.myScenarioList.scenarioOne[3].OptionThree.ToString();
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = fileReader.myScenarioList.scenarioOne[3].OptionFour.ToString();
        OptionFourScoreValue = purple;
    }

    public void Question5()
    {
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        QuestionText.text = fileReader.myScenarioList.scenarioOne[4].Question.ToString();
        
        AnswerOneText.text = fileReader.myScenarioList.scenarioOne[4].OptionOne.ToString();
        OptionOneScoreValue = red;
        AnswerTwoText.text = fileReader.myScenarioList.scenarioOne[4].OptionTwo.ToString();
        OptionTwoScoreValue = green;
        AnswerThreeText.text = fileReader.myScenarioList.scenarioOne[4].OptionThree.ToString();
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = fileReader.myScenarioList.scenarioOne[4].OptionFour.ToString();
        OptionFourScoreValue = purple;
    }

    public void Question6()
    {
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        QuestionText.text = fileReader.myScenarioList.scenarioOne[5].Question.ToString();
        
        AnswerOneText.text = fileReader.myScenarioList.scenarioOne[5].OptionOne.ToString();
        OptionOneScoreValue = red;
        AnswerTwoText.text = fileReader.myScenarioList.scenarioOne[5].OptionTwo.ToString();
        OptionTwoScoreValue = green;
        AnswerThreeText.text = fileReader.myScenarioList.scenarioOne[5].OptionThree.ToString();
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = fileReader.myScenarioList.scenarioOne[5].OptionFour.ToString();
        OptionFourScoreValue = purple;
    }
    void TimerAffectsScore() 
    {
       Score -= 50;
    }

    public void PostGameReview()
    {
        PostGameReviewContainer.SetActive(true);
        QuestionContainer.SetActive(false);

        FinalScoreText.text = $"You Scored: {Score}.";
        
        if( Score <= 3000 )
        {
            FinalFlavorText.text = "You did poorly.";
        }
        else if( Score >= 3001 && Score <= 4000 )
        {
            FinalFlavorText.text = "You did well.";
        }
        else if( Score >= 4001 && Score <= 5000 )
        {
            FinalFlavorText.text = "You did great!";
        }
        else if( Score >= 5001)
        {
            FinalFlavorText.text = "You did fantastic!";
        }
    }
}