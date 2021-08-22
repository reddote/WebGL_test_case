using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandCamera{
    public float mouseSensivity = 100f;

    //if we wont clamp the camera movement camera will eventually turn upside down
    protected float minumumValueForCamera = -90f;
    protected float maximumValueForCamera = 90f;

    //this variable name is coming from difference between rotation and mouse input 
    protected float xRotation;
    protected float yRotation;

    //Look command
    public abstract void Execute(Transform gobject, float _Input);

    //Camera or any gameobject rotation will change
    public virtual void Look(Transform objectTransform, float input){
    }
}

public class LookAtMeImCameraUpAndDown : CommandCamera //look at me I'm meeseeks
{
    public override void Execute(Transform gobject, float _Input){
        Look(gobject, _Input);
    }

    public override void Look(Transform objectTransform, float yInput){
        xRotation -= yInput;
        xRotation = Mathf.Clamp(xRotation, minumumValueForCamera, maximumValueForCamera);

        objectTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

public class ObjectBodyRotationLeftAndRight : CommandCamera{
    public override void Execute(Transform gobject, float _Input){
        Look(gobject, _Input);
    }

    //when we rotate the camera up and down camera rotation will change
    //but when we rotate the camera left and right whole player body will changed
    public override void Look(Transform objectTransform, float xInput){
        yRotation = xInput;
        objectTransform.Rotate(Vector3.up * yRotation);
    }
}