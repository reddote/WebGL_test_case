using System.Collections;
using System.Collections.Generic;
using InteractablesObjects.InteractablesObject;
using UnityEngine;

public class HtmlHook : MonoBehaviour{
    [SerializeField] private PanelOti panelOti;
    [SerializeField] private LightOti lightOti;
    [SerializeField] private CharacterOti characterOti;
    [SerializeField] private CabinetOti cabinetOti;
    [SerializeField] private DoorOti doorOti;
    [SerializeField] private BinOti binOti;

    public void CallBin(){
        binOti.StartMenuCanvasGroupEnabler();
    }

    public void CallCabinet(){
        cabinetOti.StatusChanger();
    }
    
    public void CallDoor(){
        doorOti.RestartGame();
    }
    
    public void CallLight(){
        lightOti.OpenAndCloseLight();
    }
    
    public void CallPanel(){
        panelOti.TurnUpside();
    }
    
    public void CallChar(){
        characterOti.ChangeTheAnimationForNpc();
    }

}