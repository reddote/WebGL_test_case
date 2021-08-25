using UnityEngine;

namespace InteractablesObjects.InteractablesObject{
    public class LightOti : ObjectsToInteract{
        [SerializeField] private GameObject lightGO;
        public bool isEnable = true;
        
        public void OpenAndCloseLight(){
            if (isEnable){
                isEnable = false;
            }else if (!isEnable){
                isEnable = true;
            }
            lightGO.SetActive(isEnable);
            if (isEnable){
                JavaScriptHook.current.ChangeLightTextSet("Light On");
            } else{
                JavaScriptHook.current.ChangeLightTextSet("Light Off");
            }
        }
    }
}
