using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;
using System.Linq;

public class LeaderBoardManager : MonoBehaviour
{
    private static LeaderBoardManager _instance;

    public static LeaderBoardManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LeaderBoardManager>();

            }
            return _instance;
        }
    }

    [SerializeField]
    GameObject _leaderboard;

    [SerializeField]
    private TextMeshProUGUI[] scoreFields;//this score fields is based on the number of users and their respective values

    void Start()
    {

        GetLeaderBoard();
        _leaderboard.SetActive(false);
    }

    public void TurnOffLeaderBoard()
    {
      _leaderboard.SetActive(false);  
    }
    public void TurnOnLeaderBoard()
    {
       _leaderboard.SetActive(true);
    }

    #region LEADER BOARD CODE
    private readonly string publicLeaderBoardKey = "f3b7bdef4996f7fb722c533afce42070aca3377fd8feed2483cf92315559def9";
    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderBoardKey, ((msg) =>
        {
            int loopLength = (msg.Length < scoreFields.Length) ? msg.Length : scoreFields.Length; 
            for (int i = 0; i < loopLength; i++)
            {
                scoreFields[i].text = string.Format("{0} : {1}", msg[i].Username, msg[i].Score.ToString());

            }
        }));
    }

    public void SetLeaderBoardEntry(string username, int score)
    {

        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, score, ((msg) =>
        {
        GetLeaderBoard();
        }));

    }

    #endregion
}
