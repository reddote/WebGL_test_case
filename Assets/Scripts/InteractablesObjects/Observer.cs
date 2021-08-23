using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace InteractablesObjects{
    public abstract class Observer : MonoBehaviour{
        public abstract void OnNotify(GameObject value, ObjectType objectType);
    }

    public abstract class Subject : MonoBehaviour{
        private List<Observer> observers = new List<Observer>();

        public void RegisterObserver(Observer tempObserver){
            observers.Add(tempObserver);
        }

        public void Notify(GameObject value, ObjectType objectType){
            foreach (var _x in observers){
                _x.OnNotify(value, objectType);
            }
        }
    }
}