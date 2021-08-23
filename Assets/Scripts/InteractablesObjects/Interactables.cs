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
            }else if (objectType == ObjectType.AnimationCharacter){
                //TODO change animation character
            }else if (objectType == ObjectType.Cabinet){
                //TODO Cabinet door should close and open
            }else if (objectType == ObjectType.Light){//light will open and close when it calls
                var _temp = value.GetComponent<LightOti>();
                if (_temp.isEnable){
                    _temp.isEnable = false;
                } else{
                    _temp.isEnable = true;
                }
                _temp.OpenAndCloseLight();
            }else if (objectType == ObjectType.Panel){
                //TODO Panel rotation will change
            }else if (objectType == ObjectType.Door){//game will load active scene
                var _temp = value.GetComponent<DoorOti>();
                _temp.RestartGame();
            }
        }
    }
}