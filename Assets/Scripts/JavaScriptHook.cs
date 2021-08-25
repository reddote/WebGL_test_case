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
    
}