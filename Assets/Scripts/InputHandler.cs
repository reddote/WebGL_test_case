using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class InputHandler : MonoBehaviour{
    [SerializeField] private KeyCode forward = KeyCode.W;
    [SerializeField] private KeyCode backward = KeyCode.S;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode shift = KeyCode.LeftShift;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private CharacterController playerCharacterController;

    //move pos x and z
    private float xMove, zMove;

    //all commands we use for input
    private Command moveForward, moveBackward, moveLeft, moveRight;

    private CommandCamera rotateCamera, rotatePlayerBody;
    //end for commads

    //input mouse values
    private float mouseInputX;

    private float mouseInputY;
    //end for values

    private Vector3 _move;

    private bool isPlayerRunning = false;

    private void Start(){
        //Bind with commands
        moveForward = new ForwardMove();
        moveBackward = new BackwardMove();
        moveLeft = new LeftMove();
        moveRight = new RightMove();
        rotateCamera = new LookAtMeImCameraUpAndDown();
        rotatePlayerBody = new ObjectBodyRotationLeftAndRight();
        //end
    }

    private void Update(){
        HandleInput();
        CameraInputCalculator();
    }

    private void HandleInput(){
        if (Input.GetKey(shift)){
            isPlayerRunning = true;
        } else{
            isPlayerRunning = false;
        }

        if (Input.GetKey(forward)){
            zMove = 1;
            moveForward.Execute(playerCharacterController, MoveSomethingNice(), isPlayerRunning);
        }

        if (Input.GetKey(backward)){
            zMove = -1;
            moveBackward.Execute(playerCharacterController, MoveSomethingNice(), isPlayerRunning);
        }

        if (Input.GetKey(left)){
            xMove = -1;
            moveLeft.Execute(playerCharacterController, MoveSomethingNice(), isPlayerRunning);
        }

        if (Input.GetKey(right)){
            xMove = 1;
            moveRight.Execute(playerCharacterController, MoveSomethingNice(), isPlayerRunning);
        }
    }

    private Vector3 MoveSomethingNice(){
        _move = transform.right * xMove + transform.forward * zMove;
        return _move;
    }

    private void CameraInputCalculator(){
        mouseInputX = Input.GetAxis("Mouse X") * rotateCamera.mouseSensivity * Time.deltaTime;
        mouseInputY = Input.GetAxis("Mouse Y") * rotatePlayerBody.mouseSensivity * Time.deltaTime;
        rotateCamera.Execute(cameraTransform, mouseInputY);
        rotatePlayerBody.Execute(playerTransform, mouseInputX);
    }
}