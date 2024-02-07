using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasierFollower : Kinematic
{
    public Path path; //A list of empty objects that form your path.
    public float threshold = 1f; //How close you want to be to the target before changing.

    FollowPath myMoveType;
    LookWhereGoing myRotateType;

    void Start()
    {
        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.path = path;
        myMoveType.threshold = threshold;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}