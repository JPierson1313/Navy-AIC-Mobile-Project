using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class QuestionsBehaviour : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI AnswerOneText;
    public TextMeshProUGUI AnswerTwoText;
    public TextMeshProUGUI AnswerThreeText;
    public TextMeshProUGUI AnswerFourText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    public Text FinalScoreText;
    public Text FinalFlavorText;

    public GameObject QuestionIndicator1;
    public GameObject QuestionIndicator2;
    public GameObject QuestionIndicator3;
    public GameObject QuestionIndicator4;
    public GameObject QuestionIndicator5;
    public GameObject QuestionIndicator6;

    public GameObject QuestionContainer;
    public GameObject PostGameReviewContainer;

    private int OptionOneScoreValue;
    private int OptionTwoScoreValue;
    private int OptionThreeScoreValue;
    private int OptionFourScoreValue;
    public int Score;
    public float QuestionNumber = 0f;

    private float timer;
    private int IntTimer;

    private int green = 1000;
    private int yellow = 500;
    private int purple = 50;
    private int red = -500;

    private bool buttonPressed = true;

    public float[] waitTimes = new float[] { 5, 5, 5, 5, 5, 5 };

    public PlayableDirector timeline;

    void Awake()
    {
        PostGameReviewContainer.SetActive(false);
        //QuestionContainer.SetActive(true);
    }

    public void Update()
    {
        //Debug.Log($"Score: {Score}");

        switch (QuestionNumber)
        {
            case 1:
                Question1();
                QuestionNumber += .1f;
                break;
            case 2:
                Question2();
                QuestionNumber += .1f;
                break;
            case 3:
                Question3();
                QuestionNumber += .1f;
                break;
            case 4:
                Question4();
                QuestionNumber += .1f;
                break;
            case 5:
                Question5();
                QuestionNumber += .1f;
                break;
            case 6:
                Question6();
                QuestionNumber += .1f;
                break;
            case 7:
                PostGameReview();
                break;
        }

        if (QuestionContainer.activeInHierarchy)
        {
            timer += Time.deltaTime;
            IntTimer = Mathf.FloorToInt(timer);
            TimerText.text = "";
            ScoreText.text = "";

            if (timer >= 8)
            {
                TimerText.text = (15 - IntTimer).ToString();
                TimerText.color = Color.yellow;
                //ScoreText.text = $"Score: {Score}";
            }

            if (timer >= 12)
            {
                TimerText.color = Color.red;
            }

            if (timer >= 15)
            {
                CancelInvoke("TimerAffectsScore");
                Score += red;
                timer = 0;
                IntTimer = 0;
                TimerText.color = Color.white;
                QuestionContainer.SetActive(false);
                buttonPressed = true;
                timeline.playableGraph.GetRootPlayable(0).Play();
            }
        }

        if (buttonPressed)
        {
            StartCoroutine("WaitQuestion2");
        }
    }

    public void TriggerNextQuestion()
    {
        timeline.playableGraph.GetRootPlayable(0).Pause();
        QuestionNumber += .9f;
        QuestionContainer.SetActive(true);
    }

    IEnumerator WaitQuestion2()
    {
        buttonPressed = false;
        timeline.playableGraph.GetRootPlayable(0).Play();
        yield return null;
    }
    public void Button1()
    {
        CancelInvoke("TimerAffectsScore");
        Debug.Log("Option 1");
        Score += OptionOneScoreValue;
        timer = 0;
        IntTimer = 0;
        TimerText.color = Color.white;
        buttonPressed = true;
    }

    public void Button2()
    {
        CancelInvoke("TimerAffectsScore");
        Debug.Log("Option 2");
        Score += OptionTwoScoreValue;
        timer = 0;
        IntTimer = 0;
        TimerText.color = Color.white;
        buttonPressed = true;
    }

    public void Button3()
    {
        CancelInvoke("TimerAffectsScore");
        Debug.Log("Option 3");
        Score += OptionThreeScoreValue;
        timer = 0;
        IntTimer = 0;
        TimerText.color = Color.white;
        buttonPressed = true;
    }

    public void Button4()
    {
        CancelInvoke("TimerAffectsScore");
        Debug.Log("Option 4");
        Score += OptionFourScoreValue;
        timer = 0;
        IntTimer = 0;
        TimerText.color = Color.white;
        buttonPressed = true;
    }

    public void Question1()
    {
        QuestionIndicator1.GetComponent<Image>().color = Color.green;
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        Debug.Log("Q1");
        QuestionText.text = "Two (2) country Orange aircraft take off from mix use airport. They go up to 35,000 feet at a speed of 500 kts bearing away from HVT.";

        AnswerOneText.text = "Make friendly";
        OptionOneScoreValue = red;
        AnswerTwoText.text = "Maintain unk verify IFF and flight data";
        OptionTwoScoreValue = green;
        AnswerThreeText.text = "Ask the strike group for ID";
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = "Maintain unknown";
        OptionFourScoreValue = purple;
    }

    public void Question2()
    {
        QuestionIndicator2.GetComponent<Image>().color = Color.green;
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        Debug.Log("Q2");
        QuestionText.text = "Aircraft deviate from flight plan turn 30 degrees towards HVT increase speed 550kts, maintain altitude, does not respond to communication from HYT 150 NM from HVT.";

        AnswerOneText.text = "Make aircraft hostile targets";
        OptionOneScoreValue = red;
        AnswerTwoText.text = "Query the aircraft over other channels, move good guys to CAP 50nm between aircraft and HVT";
        OptionTwoScoreValue = green;
        AnswerThreeText.text = "Ask strike group for recommendations";
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = "Recommend strike group ID aircraft as hostile";
        OptionFourScoreValue = purple;
    }

    public void Question3()
    {
        QuestionIndicator3.GetComponent<Image>().color = Color.green;
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        Debug.Log("Q3");
        QuestionText.text = "At 100NM from HVT aircrafts drops elevation to 12,000 feet, increases speed 600kts, squawks military aircraft, and have an inbound bearing on HVT.";

        AnswerOneText.text = "Ask for pilot’s recommendations";
        OptionOneScoreValue = red;
        AnswerTwoText.text = "Continue to query aircraft and have pilots safe approach VID aircraft";
        OptionTwoScoreValue = green;
        AnswerThreeText.text = "Alert aircraft to safe approach and VID enemy aircraft";
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = "Recommend strike group ID aircraft as hostile";
        OptionFourScoreValue = purple;
    }

    public void Question4()
    {
        QuestionIndicator4.GetComponent<Image>().color = Color.green;
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        Debug.Log("Q4");
        QuestionText.text = "Aircrafts drop down to 5,000 ft and accelerate to 650kts on an inbound run towards HVT. 75nm out. The pilots VID the aircraft as an enemy aircraft loaded with heavy weapons. You have been unable to establish communication with the UNK aircrafts and you have 2 fighters trailing them inbounds.";

        AnswerOneText.text = "You tell pilots to match speed and altitude and attack angle to intercept";
        OptionOneScoreValue = red;
        AnswerTwoText.text = "Alert strike group of inbound VID enemy aircraft and recommend treating them as hostiles";
        OptionTwoScoreValue = green;
        AnswerThreeText.text = "Ask for recommendations from strike group";
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = "You continue to query aircraft";
        OptionFourScoreValue = purple;
    }

    public void Question5()
    {
        QuestionIndicator5.GetComponent<Image>().color = Color.green;
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        Debug.Log("Q5");
        QuestionText.text = "Enemy aircraft break radio silence, signifies they are intent on carrying out an attack on the US for the atrocities committed against their people. Early warning indicators alert that a weapons control system is locked on HVT. Aircraft increase speed to 750kts and drop elevation to 2000ft @50nm from HVT. Strike group designates as hostile contact with hostile intent.";

        AnswerOneText.text = "Engage hostile targets with 2 aircrafts";
        OptionOneScoreValue = red;
        AnswerTwoText.text = "Recommend aircraft intercept and destroy inbound hostile targets with Strike permission";
        OptionTwoScoreValue = green;
        AnswerThreeText.text = "Continue to query aircraft and keep aircraft in pursuit ask permission from strike group";
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = "Recommend HVT launch additional air support, get recommendation from the strike group for COA";
        OptionFourScoreValue = purple;
    }

    public void Question6()
    {
        QuestionIndicator6.GetComponent<Image>().color = Color.green;
        InvokeRepeating("TimerAffectsScore", 8f, 1f);
        Debug.Log("Q6");
        QuestionText.text = "Pilots disengage once aircrafts are destroyed and returned to HVT with 2 new aircrafts being put in on station";

        AnswerOneText.text = "Send all aircrafts to CAP Station";
        OptionOneScoreValue = red;
        AnswerTwoText.text = "Send attack aircrafts to the HVT. Send new aircrafts to CAP Station";
        OptionTwoScoreValue = green;
        AnswerThreeText.text = "Send attack aircrafts to CAP Station. Send new aircrafts to HVT Station";
        OptionThreeScoreValue = yellow;
        AnswerFourText.text = "Send all aircrafts to HVT";
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

        FinalScoreText.text = $"You Scored: {Score}";

        if (Score <= 3000)
        {
            FinalFlavorText.text = "You did poorly!";
        }
        else if (Score >= 3001 && Score <= 4000)
        {
            FinalFlavorText.text = "You did well!";
        }
        else if (Score >= 4001 && Score <= 5000)
        {
            FinalFlavorText.text = "You did great!";
        }
        else if (Score >= 5001)
        {
            FinalFlavorText.text = "You did fantastic!";
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}