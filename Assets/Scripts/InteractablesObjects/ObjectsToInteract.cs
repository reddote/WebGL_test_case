using UnityEngine;

namespace InteractablesObjects{
    public class ObjectsToInteract : Subject{
        [SerializeField] private ObjectType objectType;
        
        protected virtual void OnMouseDown(){
            Notify(gameObject, objectType);
        }
    }
}
