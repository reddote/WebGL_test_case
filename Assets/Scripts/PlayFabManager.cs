using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;
using PlayFab;

public class PlayFabManager : MonoBehaviour{
    public static PlayFabManager current;
    
    private Dictionary<string, float> leaderBoardList = new Dictionary<string, float>();
    public List<string> stringTimeValue = new List<string>();
    public List<string> stringLeaderBoard = new List<string>();
    private int count = 1;
    public bool isGetLeader = false;
    
    private void Awake(){
        current = this;
    }

    void Start(){
        Login();
    }

    private void Update(){
        if (!isGetLeader){//a little bit slow to get leaderboard so if we need to update text we should use this
            GetLeaderBoard();
            isGetLeader = true;
        }
    }

    private void Login(){
        var _request = new LoginWithCustomIDRequest{
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
        };
        PlayFabClientAPI.LoginWithCustomID(_request,OnSuccess,OnError);
    }

    private void OnSuccess(LoginResult result){
        Debug.Log("Successful login/account created!");
    }

    private void OnError(PlayFabError error){
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderBoard(float time){
        time *= 100;
        int _timeToint = (int)time;
        var _request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>(){
                new StatisticUpdate{
                    StatisticName = "Time",
                    Value = _timeToint
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(_request, OnLeaderBoardUpdate, OnError);
    }

    private void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Successful leaderboard send");
    }

    public void GetLeaderBoard(){
        var _request = new GetLeaderboardRequest{
            StatisticName = "Time",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(_request, OnLeaderBoardGet, OnError);
    }

    private void OnLeaderBoardGet(GetLeaderboardResult result){
        leaderBoardList.Clear();
        stringLeaderBoard.Clear();
        foreach (var _item in result.Leaderboard){
            if (count > 10){
                break;
            } else{
                float _temp = (float) -(_item.StatValue / 100f);
                if (!leaderBoardList.ContainsKey(_item.PlayFabId)){
                    leaderBoardList.Add(_item.PlayFabId,_temp);
                }
                count++;
            }
        }
        int _count = 1;
        foreach (var _item in leaderBoardList){
            string _b = _count + "." + _item.Value;
            JavaScriptHook.current.ChangeHighScoreTextSet(_b, (_count));
            stringTimeValue.Add(_b);
            string _a = (_count + " ID: " + _item.Key + " Time : " + _item.Value);
             stringLeaderBoard.Add(_a);
            _count++;
        }
    }
}