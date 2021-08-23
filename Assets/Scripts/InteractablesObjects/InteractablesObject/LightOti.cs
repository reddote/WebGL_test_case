using UnityEngine;

namespace InteractablesObjects.InteractablesObject{
    public class LightOti : ObjectsToInteract{
        [SerializeField] private GameObject lightGO;
        public bool isEnable = true;

        public void OpenAndCloseLight(){
            lightGO.SetActive(isEnable);
        }
    }
}
