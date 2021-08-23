using System;
using UnityEngine;

namespace InteractablesObjects.InteractablesObject{
    public enum CabinetDoorStatus{
        Open = 0,
        Close = 1
    }
    public class CabinetOti : ObjectsToInteract{
        [SerializeField] private Transform cabinetDoor;
        [SerializeField] private Transform closedLocation;
        [SerializeField] private Transform openedLocation;
        private float speed = .3f;
        public CabinetDoorStatus doorStatus;

        private void Start(){
            doorStatus = CabinetDoorStatus.Close;
        }

        private void Update(){
            switch (doorStatus){
                case CabinetDoorStatus.Close:
                    if (cabinetDoor.transform.localPosition.x >= closedLocation.transform.localPosition.x){
                        MoveDoorByStatus( -1);
                    }
                    break;
                case CabinetDoorStatus.Open:
                    if (cabinetDoor.transform.localPosition.x <= openedLocation.transform.localPosition.x){
                        MoveDoorByStatus( 1);
                    }
                    break;
            }
        }

        public string GetStatusOfDoor(){
            return doorStatus.ToString();
        }

        public void StatusChanger(){
            if (doorStatus == CabinetDoorStatus.Open){
                doorStatus = CabinetDoorStatus.Close;
            }else if (doorStatus == CabinetDoorStatus.Close){
                doorStatus = CabinetDoorStatus.Open;
            }
        }

        private void MoveDoorByStatus(int direction){
            cabinetDoor.transform.localPosition += Vector3.right * (Time.deltaTime * direction * speed);
        }
    }
}
