using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BehaviorAndWeight
{
    public SteeringBehavior behavior;
    public float weight;
    public BehaviorAndWeight(SteeringBehavior behavior, float weight)
    {
        this.behavior = behavior;
        this.weight = weight;
    }
}
public class BlendedSteering : SteeringBehavior
{
    public BehaviorAndWeight[] behaviors;

    float maxAcceleration = 1f;
    float maxRotation = 5f;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new ();

        foreach (var behavior in behaviors)
        {
            SteeringOutput behaviourOutput = behavior.behavior.getSteering();
            result.linear += behavior.weight * behaviourOutput.linear;
            result.angular += behavior.weight * behaviourOutput.angular;
        }

        //result.linear = Vector3.Min(result.linear, Vector3.one * maxAcceleration);
        //result.angular = Mathf.Min(result.angular, maxRotation);

        result.linear = result.linear * maxAcceleration;
        float angular = Mathf.Abs(result.angular);
        if (angular > maxRotation)
        {
            result.angular /= angular;
            result.angular *= maxAcceleration;
        }
        return result;
    }
}
