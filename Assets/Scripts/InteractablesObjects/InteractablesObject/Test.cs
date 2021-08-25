using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace InteractablesObjects.InteractablesObject{

    public enum TestStatus{
        Idle = 0,
        SitOnChair = 1,
        StandUpChair = 2,
        LaughOnChair = 3,
        Handshake = 4,
        Move = 5,
        TalkSit = 6
    }
    
    public class Test : ObjectsToInteract{
        [SerializeField] private Animator npcAnimator;
        private int animationNumber = 0;
        
        private void Start(){
            npcAnimator = GetComponent<Animator>();
        }

        public void TestFunc(){
            Debug.LogError("Teste girdi");
            animationNumber++;
            if (animationNumber > 6){
                animationNumber = 0;
            }
            npcAnimator.SetInteger("Change", animationNumber);
            Debug.LogError("Testde");
        }

    }
}
