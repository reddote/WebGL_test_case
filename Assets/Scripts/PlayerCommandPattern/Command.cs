using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command{
    protected float playerWalkSpeed = 5f;
    protected float playerRunningSpeed = 7f;

    //Move command
    public abstract void Execute(CharacterController gobject, Vector3 move, bool isRunning);

    //player or any gameobject position will change
    //require charactercontroller
    public virtual void Move(CharacterController objectTransform, Vector3 move, bool isRunning){
    }
}

public class ForwardMove : Command{
    public override void Execute(CharacterController gobject, Vector3 move, bool isRunning){
        Move(gobject, move, isRunning);
    }

    public override void Move(CharacterController objectTransform, Vector3 move, bool isRunning){
        if (isRunning){
            objectTransform.Move(move * (playerRunningSpeed * Time.deltaTime));
        } else{
            objectTransform.Move(move * (playerWalkSpeed * Time.deltaTime));
        }
    }
}

public class BackwardMove : Command{
    public override void Execute(CharacterController gobject, Vector3 move, bool isRunning){
        Move(gobject, move, isRunning);
    }

    public override void Move(CharacterController objectTransform, Vector3 move, bool isRunning){
        objectTransform.Move(move * (playerWalkSpeed * Time.deltaTime));
    }
}

public class LeftMove : Command{
    public override void Execute(CharacterController gobject, Vector3 move, bool isRunning){
        Move(gobject, move, isRunning);
    }

    public override void Move(CharacterController objectTransform, Vector3 move, bool isRunning){
        if (isRunning){
            objectTransform.Move(move * (playerRunningSpeed * Time.deltaTime));
        } else{
            objectTransform.Move(move * (playerWalkSpeed * Time.deltaTime));
        }
    }
}

public class RightMove : Command{
    public override void Execute(CharacterController gobject, Vector3 move, bool isRunning){
        Move(gobject, move, isRunning);
    }

    public override void Move(CharacterController objectTransform, Vector3 move, bool isRunning){
        if (isRunning){
            objectTransform.Move(move * (playerRunningSpeed * Time.deltaTime));
        } else{
            objectTransform.Move(move * (playerWalkSpeed * Time.deltaTime));
        }
    }
}