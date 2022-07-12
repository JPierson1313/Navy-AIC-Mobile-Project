using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;

public class ShowLeaderboard : MonoBehaviour
{
    int MaxScores = 8;
    public Text[] EntriesName;
    public Text[] EntriesScore;
    public static int ID = 2386;

    public GameObject LeaderboardCanvas;

    public void ShowScores()
    {
        LeaderboardCanvas.SetActive(true);

        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    EntriesName[i].text = (scores[i].rank + ". " + scores[i].member_id);
                    EntriesScore[i].text = (scores[i].score).ToString();
                }

                if (scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        EntriesName[i].text = (i + 1).ToString() + ".    none";
                    }
                }
            }
            else
            {
                Debug.Log("Failed");
            }
        }); ;
    }

    public void BackButton()
    {
        LeaderboardCanvas.SetActive(false);
    }

    private void Awake()
    {
        LeaderboardCanvas.SetActive(false);
    }

    void Start()
    {
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
}
