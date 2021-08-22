using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace PlayerStatePattern{
    public enum PlayerStates{
        Walking,
        Running,
        Jumping,
        OnFeet,
    }
    
    public static class AnimatorParameters
    {
        public static readonly int Walk = Animator.StringToHash("Walk");
        public static readonly int Run = Animator.StringToHash("Run");
        public static readonly int Jumping = Animator.StringToHash("Jump");
        public static readonly int Idle = Animator.StringToHash("Idle");

    }


    public class PlayerController : MonoBehaviour{
        //default player state
        public PlayerStates playerState;
        
        //SerializeField private values
        [SerializeField] private Transform groundCheck;//this object will collide ground
        [SerializeField] private LayerMask groundMask;//this will check which ground we are on
        
        //private variables
        private Animator animator;
        private Vector3 velocity = Vector3.zero;
        private float gravity = -9.81f;
        private float groundDistance = 0.4f;//it is distance the between ground and groundcheck object
        private float jumpHeight = 3f;
        private bool isGrounded = false;

        private void Start(){
            playerState = PlayerStates.OnFeet;
            animator = GetComponentInChildren<Animator>();
        }

        private void Update(){
            switch (playerState){
                case PlayerStates.OnFeet:
                    animator.SetTrigger(AnimatorParameters.Idle);
                    break;
                case PlayerStates.Walking:
                    animator.SetTrigger(AnimatorParameters.Walk);
                    break;
                case PlayerStates.Running:
                    animator.SetTrigger(AnimatorParameters.Jumping);
                    break;
                case PlayerStates.Jumping:
                    PlayerJump();
                    animator.SetTrigger(AnimatorParameters.Jumping);
                    break;
            }
        }

        public void PlayerGravityController(CharacterController characterController){
            //it will check if our player is grounded via invisible sphere
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            
            if (isGrounded && velocity.y < 0){
                velocity.y = -2f;
            } 

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
        

        private void PlayerJump(){
            if (isGrounded){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
            }
        }
    }
}