using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FileReader : MonoBehaviour
{
    public TextAsset textJSON;

    [System.Serializable]
    public class ScenarioOne
    {
        public int QuestionIndex;
        public string Question;
        public string OptionOne;
        public string OptionTwo;
        public string OptionThree;
        public string OptionFour;
        public int GreenScore;
        public int YellowScore;
        public int PurpleScore;
        public int RedScore;
    }

    [System.Serializable]
    public class ScenarioTwo
    {
        public int QuestionIndex;
        public string Question;
        public string OptionOne;
        public string OptionTwo;
        public string OptionThree;
        public string OptionFour;
        public int GreenScore;
        public int YellowScore;
        public int PurpleScore;
        public int RedScore;
    }

    [System.Serializable]
    public class ScenarioList
    {
        public ScenarioOne[] scenarioOne;
        public ScenarioTwo[] scenarioTwo;
    }

    public ScenarioList myScenarioList = new ScenarioList();
    void Start()
    {
        myScenarioList = JsonUtility.FromJson<ScenarioList>(textJSON.text);
    }
}