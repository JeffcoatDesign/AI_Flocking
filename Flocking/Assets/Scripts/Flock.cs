using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


//Optimization
public class Flock : MonoBehaviour
{
    public static Flock instance;
    public List<Flocker> flockers;
    public Kinematic flockCenter;
    private void Awake()
    {
        instance = this;
        flockers = FindObjectsByType<Flocker>(FindObjectsSortMode.None).ToList();
    }

    private void Update()
    {
        //Vector3 center = Vector3.zero;
        //Vector3 velocity = Vector3.zero;
        //foreach (Flocker flocker in flockers)
        //{
        //    center += flocker.transform.position;
        //    velocity += flocker.linearVelocity;
        //}
        //center /= flockers.Count;
        //velocity /= flockers.Count;

        //if (flockers.Count < 1) return;
        //flockCenter.transform.position = center;
        //flockCenter.linearVelocity = velocity;
    }
}
