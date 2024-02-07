using UnityEngine;

public class FollowPath : Seek
{
    public Path path;
    public float threshold;

    private int index = 0;

    protected override Vector3 getTargetPosition()
    {
        Vector3 directionToTarget = path.pathNodes[index].transform.position - character.transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (distanceToTarget < threshold)
        {
            index++;
            if (index >= path.pathNodes.Length)
                index = 0;
        }


        return path.pathNodes[index].transform.position;
    }
}