using System.Runtime.InteropServices;
using UnityEngine;

public class JavaScriptHook : MonoBehaviour{
    public static JavaScriptHook current;

    private void Awake(){
        current = this;
    }

    [DllImport("__Internal")]
    private static extern void ChangeAnimationText(string name);

    [DllImport("__Internal")]
    private static extern void ChangeLightText(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeCabinetText(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeUICountText(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeUITimerText(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangePanelText(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore1Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore2Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore3Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore4Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore5Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore6Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore7Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore8Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore9Text(string status);
    
    [DllImport("__Internal")]
    private static extern void ChangeHighScore10Text(string status);
    
    
    public void ChangeAnimationTextSet(string animationName){
        ChangeAnimationText(animationName);
    }

    public void ChangeLightTextSet(string statusName){
        ChangeLightText(statusName);
    }

    public void ChangeCabinetTextSet(string statusName){
        ChangeCabinetText(statusName);   
    }
    
    public void ChangeUICountTextSet(string statusName){
        ChangeUICountText(statusName);   
    }
    
    public void ChangeUITimerTextSet(string statusName){
        ChangeUITimerText(statusName);   
    }
    
    public void ChangePanelTextSet(string statusName){
        ChangePanelText(statusName);   
    }
    
    public void ChangeHighScoreTextSet(string statusName, int id){
        switch (id){
            case 1:
                ChangeHighScore1Text(statusName);
                break;
            case 2:
                ChangeHighScore2Text(statusName);
                break;
            case 3:
                ChangeHighScore3Text(statusName);
                break;
            case 4:
                ChangeHighScore4Text(statusName);
                break;
            case 5:
                ChangeHighScore5Text(statusName);
                break;
            case 6:
                ChangeHighScore6Text(statusName);
                break;
            case 7:
                ChangeHighScore7Text(statusName);
                break;
            case 8:
                ChangeHighScore8Text(statusName);
                break;
            case 9:
                ChangeHighScore9Text(statusName);
                break;
            case 10:
                ChangeHighScore10Text(statusName);
                break;
        }
    }

    
}