using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    public int ID;
    int MaxScores = 5;
    public TMP_Text[] Entries;

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
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

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].rank + ".   \t").ToString();
                    Entries[i].text += (scores[i].member_id + ":   \t").ToString();
                    Entries[i].text += (scores[i].score).ToString();

                }
                if (scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + "\tnone";
                    }
                }

            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text.Substring(0, 6), int.Parse(PlayerScore.text), ID, (response) =>
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
