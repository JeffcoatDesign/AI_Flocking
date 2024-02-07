using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionAvoider : Kinematic
{
    CollisionAvoidance myMoveType;
    Align myRotateType;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new ();
        myMoveType.character = this;
        List<Kinematic> kinematics = FindObjectsByType<Kinematic>(FindObjectsSortMode.None).ToList();
        kinematics.Remove(this);
        myMoveType.targets = kinematics.ToArray();
        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
