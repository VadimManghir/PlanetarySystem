using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour
{
    public string Kind; 
    public float Mass, Radius;
    public Transform orbit;


    public void Move(float deltaTime)
    {
        orbit.Rotate(0, 0, deltaTime * Mass);
    }
}
