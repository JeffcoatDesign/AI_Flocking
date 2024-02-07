using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMatch : SteeringBehavior
{
    public float maxAcceleration;

    float timeToTarget = 0.1f;
    public Kinematic character;
    public Kinematic target;
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.linear = target.linearVelocity - character.linearVelocity;
        result.linear /= timeToTarget;

        if (result.linear.magnitude > maxAcceleration )
        {
            result.linear.Normalize();
            result.linear *= maxAcceleration;
        }

        result.angular = 0;
        return result;
    }
}
