using UnityEngine;

namespace InteractablesObjects.InteractablesObject{
    public enum PanelDoorStatus{
        Straight = 0,
        Opposite = 1
    }
    
    public class PanelOti : ObjectsToInteract{
        [SerializeField] private Transform panelTransform;
        [SerializeField] private PanelDoorStatus panelDoorStatus;
        private Vector3 firstLocation;
        private Vector3 secondLocation;

        public void Start(){
            panelTransform = transform;
            panelDoorStatus = PanelDoorStatus.Straight;
            firstLocation = new Vector3(
                0,
                90f,
                0f);
            secondLocation = new Vector3(
                panelTransform.rotation.x,
                90f,
                180f);
            
        }
        
        public void TurnUpside(){
            switch (panelDoorStatus){
                case PanelDoorStatus.Straight:
                    panelTransform.rotation = Quaternion.Euler(secondLocation);
                    panelDoorStatus = PanelDoorStatus.Opposite;
                    string _temp2 = "Words: " + panelDoorStatus.ToString();
                    JavaScriptHook.current.ChangePanelTextSet(_temp2);
                    break;
                case PanelDoorStatus.Opposite:
                    var _rotation = panelTransform.rotation;
                    panelTransform.rotation = Quaternion.Euler(firstLocation);
                    panelDoorStatus = PanelDoorStatus.Straight;
                    string _temp1 = "Words: " + panelDoorStatus.ToString();
                    JavaScriptHook.current.ChangePanelTextSet(_temp1);
                    break;
            }
        }
    }
}
