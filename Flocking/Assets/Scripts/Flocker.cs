using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flocker : Kinematic
{
    BlendedSteering myMoveType;
    List<Flocker> flock;
    //Kinematic flockCenter;

    // Start is called before the first frame update
    void Start()
    {
        //flockCenter = new GameObject().AddComponent<Kinematic>();
        List<BehaviorAndWeight> behaviors = new();
        flock = new (Flock.instance.flockers.ToArray());
        flock.Remove(this);

        myMoveType = new ();
        
        Separation separation = new ();
        separation.character = this;
        separation.targets = flock.ToArray();
        BehaviorAndWeight seperationBehavior = new BehaviorAndWeight(separation, 3f);
        behaviors.Add(seperationBehavior);

        VelocityMatch velocityMatch = new VelocityMatch();
        velocityMatch.character = this;
        velocityMatch.target = Flock.instance.flockCenter;
        BehaviorAndWeight velocitymatchBehavior = new BehaviorAndWeight(velocityMatch, 1f);
        behaviors.Add(velocitymatchBehavior);

        LookWhereGoing lookWhereGoing = new LookWhereGoing();
        lookWhereGoing.character = this;
        BehaviorAndWeight lookBehavior = new BehaviorAndWeight (lookWhereGoing, 1f);
        behaviors.Add(lookBehavior);

        Arrive arrive = new Arrive();
        arrive.character = this;
        arrive.target = Flock.instance.flockCenter.gameObject;
        BehaviorAndWeight arriveBehavior = new BehaviorAndWeight(arrive, .4f);
        behaviors.Add(arriveBehavior);

        myMoveType.behaviors = behaviors.ToArray();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Vector3 center = Vector3.zero;
        //Vector3 velocity = Vector3.zero;
        //foreach (Flocker flocker in flock)
        //{
        //    center += flocker.transform.position;
        //    velocity += flocker.linearVelocity;
        //}
        //center /= flock.Count;
        //velocity /= flock.Count;

        //if (flock.Count < 1) return;
        //flockCenter.transform.position = center;
        //flockCenter.linearVelocity = velocity;

        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myMoveType.getSteering().angular;
        base.Update();
    }
}
