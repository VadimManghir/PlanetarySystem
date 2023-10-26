using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour
{
    public PlanetaryObject[] planetaryObjects;



    public void update(float deltaTime)
    {
        foreach(PlanetaryObject planetaryObject in planetaryObjects) 
        {
            planetaryObject.Move(deltaTime);
        }
    }
}
