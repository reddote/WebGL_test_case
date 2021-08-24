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
            
            //sometimes object can not stay in ground and falling infinite probably because of collider
            //this will fix it
            if (transform.position.y <= -40){
                transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
            }
        }

        public bool HaveObjectsInMyHand(){
            return parentPoolObject.haveObjectinHands;
        }

        public void ObjectIsGrabbed(){
            parentPoolObject.haveObjectinHands = true;
            rigidbodyGrabObject.isKinematic = true;
            grabObject.SetParent(carryLocation);
            grabObject.localPosition = Vector3.zero;
        }

        public void DropObject(){
            parentPoolObject.haveObjectinHands = false;
            grabObject.SetParent(null);
            rigidbodyGrabObject.isKinematic = false;
        }

        private void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("Bin")){
                //TODO when drop the bin
                parentPoolObject.RemoveObjectsWhenDroppedBin(transform);
                var _temp = other.GetComponentInParent<BinOti>();
                int _droppedObjectCount = parentPoolObject.DroppedObjectCount();
                _temp.CountTextUpdater(_droppedObjectCount);
            }
        }
    }
}