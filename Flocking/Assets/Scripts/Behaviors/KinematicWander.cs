using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicWander : SteeringBehavior
{
    public Kinematic character;
    float maxAcceleration = 1f;
    float maxRotation = 10f;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.linear = maxAcceleration * character.transform.forward;
        result.angular = RandomBinomial() * maxRotation;

        return result;
    }

    private float RandomBinomial ()
    {
        return Random.value - Random.value;
    }
}
