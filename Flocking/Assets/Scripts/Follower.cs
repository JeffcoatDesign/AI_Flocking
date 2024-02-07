using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Follower : Kinematic
{
    public float pathOffset = 1f;
    public Path path;

    FollowPathPredictive myMoveType;
    LookWhereGoing myRotateType;

    void Start()
    {
        myMoveType = new();
        myMoveType.character = this;
        myMoveType.path = path;
        myMoveType.pathOffset = pathOffset;
        myMoveType.target = myTarget;

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
