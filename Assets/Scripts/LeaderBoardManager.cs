using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    private TextMeshProUGUI TextPrefab;

    int numUsers = 5;//testing remove number
    private TextMeshProUGUI[] scoreFields;//this score fields is based on the number of users and their respective values

    int tempScore = 100;    //test variables remove for score and user input 
    string tempUser = "user";

    void Start()
    {
        scoreFields = new TextMeshProUGUI[numUsers];

        for (int i = 0; i < numUsers; i++)
        {
            //here we need to setup our text fields
            scoreFields[i] = Instantiate(TextPrefab);
            scoreFields[i].transform.SetParent(TextPrefab.transform.parent, false);

        }
        Destroy(TextPrefab.gameObject);

    }

    void Update()
    {
        for (int i = 0; i < numUsers; i++)
        {
            scoreFields[i].text = string.Format("{0} score:{1}",tempUser , tempScore.ToString());// replace for username on first and score on second 
        }
    }
}
