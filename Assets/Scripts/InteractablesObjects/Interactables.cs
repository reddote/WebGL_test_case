using System;
using System.Collections;
using System.Collections.Generic;
using InteractablesObjects.InteractablesObject;
using UnityEngine;

namespace InteractablesObjects{
    public enum ObjectType{
        Light,
        Cabinet,
        AnimationCharacter,
        Door,
        Panel,
        Bin,
        Grab
    }

    public class Interactables : Observer
    {
        private void Start(){
            PlayerPrefs.DeleteAll();

            foreach (var _oti in FindObjectsOfType<ObjectsToInteract>()){
                _oti.RegisterObserver(this);
            }
        }

        public override void OnNotify(GameObject value, ObjectType objectType){
            if (objectType == ObjectType.Bin){
                //TODO open the UI canvas
                var _temp = value.GetComponent<BinOti>();
                if (!_temp.isGameStarted){
                    _temp.StartMenuCanvasGroupEnabler();
                }
            }else if (objectType == ObjectType.AnimationCharacter){//every interaction animation will change
                var _temp = value.GetComponent<CharacterOti>();
                _temp.ChangeTheAnimationForNpc();
            }else if (objectType == ObjectType.Cabinet){//cabinet door will open and close
                //TODO Cabinet door should close and open
                var _temp = value.GetComponent<CabinetOti>();
                _temp.StatusChanger();
            }else if (objectType == ObjectType.Light){//light will open and close when it calls
                var _temp = value.GetComponent<LightOti>();
                _temp.OpenAndCloseLight();
            }else if (objectType == ObjectType.Panel){//panel will turn upside down
                //TODO Panel rotation will change
                var _temp = value.GetComponent<PanelOti>();
                _temp.TurnUpside();
            }else if (objectType == ObjectType.Door){//game will load active scene
                var _temp = value.GetComponent<DoorOti>();
                _temp.RestartGame();
            }else if (objectType == ObjectType.Grab){
                var _temp = value.GetComponent<GrabOti>();
                if (!_temp.HaveObjectsInMyHand()){
                    _temp.ObjectIsGrabbed();
                }
            }
        }
    }
}