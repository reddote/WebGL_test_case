using System;
using UnityEngine;

namespace InteractablesObjects.InteractablesObject{
    public class GrabOti : ObjectsToInteract{
        [SerializeField] private Spawner parentPoolObject;
        [SerializeField] private Transform grabObject;
        [SerializeField] private Transform carryLocation;
        private Rigidbody rigidbodyGrabObject;

        private void Start(){
            grabObject = transform;
            parentPoolObject = GetComponentInParent<Spawner>();
            rigidbodyGrabObject = GetComponent<Rigidbody>();
        }

        private void Update(){
            if (Input.GetKeyDown(KeyCode.F)){
                DropObject();
            }
        }

        public void ObjectIsGrabbed(){
            rigidbodyGrabObject.isKinematic = true;
            grabObject.SetParent(carryLocation);
            grabObject.localPosition = Vector3.zero;
        }

        public void DropObject(){
            grabObject.SetParent(null);
            rigidbodyGrabObject.isKinematic = false;
        }

        private void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("Bin")){
                //TODO when drop the bin
                parentPoolObject.RemoveObjectsWhenDroppedBin(transform);
            }
        }
    }
}