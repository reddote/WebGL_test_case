using System;
using System.Collections.Generic;
using System.ComponentModel;
using InteractablesObjects.InteractablesObject;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace InteractablesObjects{
    public class Spawner : MonoBehaviour{
        public static Spawner current;
        [SerializeField] private Transform spawnPoint1;
        [SerializeField] private Transform spawnPoint2;
        
        [SerializeField] private List<Transform> cubes = new List<Transform>();
        //this will control the when game is finished
        [SerializeField] private List<Transform> controlList = new List<Transform>();
        
        //events
        public event Action isGameFinished;
        public bool haveObjectinHands = false;

        public void GameFinishController(){
            isGameFinished?.Invoke();
        }

        private void Awake(){
            current = this;
        }

        private void Start(){//spawner is parent object for pooling
            foreach (Transform _child in transform){//get all graboti objects from child
                cubes.Add(_child);
                controlList.Add(_child);
            }
        }

        private void Update(){
            if (controlList.Count <= 0){//check objects if 0 then game is finished.
                GameFinishController();
                ReturnObjectPool();
                Debug.Log("countdown");
            } 
        }

        public void ObjectSpawner(){
            for (int i = 0; i < cubes.Count; i++){
                var _temp = cubes[i].GetComponent<GrabOti>();
                cubes[i].position = LocationCalculator();
                _temp.DropObject();
            }
        }

        private void ReturnObjectPool(){
            foreach (var _temp in cubes){
                _temp.SetParent(transform);
                controlList.Add(_temp);
            }
        }

        public void RemoveObjectsWhenDroppedBin(Transform grabOti){
            controlList.RemoveAt(controlList.IndexOf(grabOti));
        }

        public int DroppedObjectCount(){//count objects in bin
            return cubes.Count - controlList.Count;
        }

        private Vector3 LocationCalculator(){
            var _position = spawnPoint1.position;
            var _position1 = spawnPoint2.position;
            float x = Random.Range(_position.x, _position1.x);
            float z = Random.Range(_position.z, _position1.z);
            return new Vector3(x,_position.y,z);
        }

    }
}