using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    float m_avoidDistance = 2.5f;
    float m_rayLength = 10f;

    Vector3 targetPos;
    public override SteeringOutput getSteering()
    {
        Ray ray = new()
        {
            direction = character.linearVelocity,
            origin = character.transform.position
        };
        if (Physics.Raycast(ray, out RaycastHit hit, m_rayLength))
        {
            targetPos = hit.point + hit.normal * m_avoidDistance;
        }
        else
        {
            targetPos = base.getTargetPosition();
        }

        return base.getSteering();
    }
    protected override Vector3 getTargetPosition()
    {
        return targetPos;
    }
}
