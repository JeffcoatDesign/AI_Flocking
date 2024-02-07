using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathPredictive : Seek
{
    public Path path;
    public float pathOffset;

    private float currentParam;

    private float predictTime = 0.1f;

    Vector3 targetPos;
    protected override Vector3 getTargetPosition()
    {
        return targetPos;
    }

    public override SteeringOutput getSteering()
    {
        Vector3 futurePos = character.transform.position + character.linearVelocity * predictTime;

        currentParam = path.GetParam(futurePos, character.transform.position);

        float targetParam = currentParam + pathOffset;

        targetPos = path.GetPosition(targetParam);

        return base.getSteering();
    }
}
