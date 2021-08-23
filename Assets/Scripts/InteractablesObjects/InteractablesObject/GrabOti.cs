using System;
using UnityEngine;

namespace InteractablesObjects.InteractablesObject{
    public class GrabOti : ObjectsToInteract{
        [SerializeField] private Transform grabObject;
        [SerializeField] private Transform carryLocation;
        private Rigidbody rigidbodyGrabObject;

        private void Start(){
            grabObject = transform;
            rigidbodyGrabObject = GetComponent<Rigidbody>();
        }

        private void ObjectIsGrabbed(){
            rigidbodyGrabObject.isKinematic = true;
            grabObject.SetParent(carryLocation);
            grabObject.position = Vector3.zero;
        }

        private void DropObject(){
            grabObject.SetParent(null);
            rigidbodyGrabObject.isKinematic = false;
        }

        private void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("Bin")){
                //TODO when drop the bin
            }
        }
    }
}