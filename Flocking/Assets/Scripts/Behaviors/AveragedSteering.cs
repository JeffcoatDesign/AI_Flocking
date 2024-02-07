using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveragedSteering : SteeringBehavior
{
    public SteeringBehavior[] movementBehaviors;
    public SteeringBehavior[] rotateBehaviors;

    public float maxAcceleration;
    public float maxRotation;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new();

        foreach (var behavior in movementBehaviors)
        {
            SteeringOutput behaviourOutput = behavior.getSteering();
            result.linear += behaviourOutput.linear;
        }
        result.linear /= movementBehaviors.Length;

        foreach (var behavior in rotateBehaviors)
        {
            SteeringOutput behaviourOutput = behavior.getSteering();
            result.angular += behaviourOutput.angular;
        }
        result.angular /= movementBehaviors.Length;

        result.linear = Vector3.Min(result.linear, Vector3.one * maxAcceleration);
        result.angular = Mathf.Min(result.angular, maxRotation);
        return result;
    }
}