using UnityEngine;

namespace InteractablesObjects.InteractablesObject{
    public enum PanelDoorStatus{
        Straight = 0,
        Opposite = 1
    }
    
    public class PanelOti : ObjectsToInteract{
        [SerializeField] private Transform panelTransform;
        [SerializeField] private PanelDoorStatus panelDoorStatus;

        public void Start(){
            panelTransform = transform;
            panelDoorStatus = PanelDoorStatus.Straight;
        }
        
        public void TurnUpside(){
            var _rotation = panelTransform.rotation;
            panelTransform.rotation = Quaternion.Euler(new Vector3(
                _rotation.x,
                90f,
                180f));
            panelDoorStatus = PanelDoorStatus.Opposite;
            string _temp = "Words: " + panelDoorStatus.ToString();
            JavaScriptHook.current.ChangePanelTextSet(_temp);
        }
    }
}
