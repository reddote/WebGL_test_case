using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace InteractablesObjects.InteractablesObject{

    public enum AnimationNames{
        Idle = 0,
        SitOnChair = 1,
        StandUpChair = 2,
        LaughOnChair = 3,
        Handshake = 4,
        Move = 5,
        TalkSit = 6
    }
    
    public class CharacterOti : ObjectsToInteract{
        [SerializeField] private Animator npcAnimator;
        //private Dictionary<int, string> animationNames = new Dictionary<int, string>();
        private int animationNumber = 0;

        private void Start(){
            npcAnimator = GetComponent<Animator>();
            JavaScriptHook.current.ChangeAnimationTextSet(GetAnimationName());
        }

        public void ChangeTheAnimationForNpc(){
            animationNumber++;
            if (animationNumber > 6){
                animationNumber = 0;
            }
            npcAnimator.SetInteger("Change", animationNumber);
            JavaScriptHook.current.ChangeAnimationTextSet(GetAnimationName());
        }

        private string GetAnimationName(){
            var _displayNameOfAnimation = (AnimationNames) animationNumber;
            string _animationName = _displayNameOfAnimation.ToString();
            return _animationName;
        }
        
    }
}
