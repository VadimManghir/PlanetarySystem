using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class KindOfPlanietaryObject
{
    public string name;
    public float minMass, maxMass, minRadius, maxRadius; 
    public float CalculateRadius(float mass)
    {
        return (mass - minMass)/((maxMass - minMass)/100) * ((maxRadius - minRadius) / 100) + minRadius;
    }
    
    
}



public class PlanetarySystemFactory : MonoBehaviour
{
    [SerializeField]
    private KindOfPlanietaryObject[] kindsOfPlanietaryObject;
    [SerializeField]
    private GameObject planytaryObjectPrefab ,planytaryObjectInfoPrefab, orbitPrefab ;
    [SerializeField]
    private Transform infoContent;
    [SerializeField]
    private PlanetarySystem planetarySystem;



    void Start()
    {
        CreateNewRandomPlanetaryObject(UnityEngine.Random.Range(3,6));        
    }

    private void CreateNewRandomPlanetaryObject(int quantity = 3)
    {
       float orbitFactor = 3;

       while(quantity > 0)
       {

        KindOfPlanietaryObject kindOfNewPlanietaryObject = kindsOfPlanietaryObject[UnityEngine.Random.Range(0 , kindsOfPlanietaryObject.Length)];

            float massOfNewPlanytaryObject = UnityEngine.Random.Range(kindOfNewPlanietaryObject.minMass, kindOfNewPlanietaryObject.maxMass);
            float radiusOfNewPlanytaryObject = kindOfNewPlanietaryObject.CalculateRadius(massOfNewPlanytaryObject);
            string kindOfNewPlanytaryObject = kindOfNewPlanietaryObject.name;

        
        GameObject NewPlanytaryGameObject = Instantiate(planytaryObjectPrefab);
        GameObject NewOrbit = Instantiate(orbitPrefab, Vector3.zero , Quaternion.Euler(0f,0f, UnityEngine.Random.Range(0f, 360f)));
        NewPlanytaryGameObject.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        NewPlanytaryGameObject.transform.localScale = new Vector3(radiusOfNewPlanytaryObject, radiusOfNewPlanytaryObject, 1);
        orbitFactor +=  radiusOfNewPlanytaryObject;
        NewOrbit.transform.localScale = new Vector3(orbitFactor, orbitFactor, 1);
        orbitFactor += radiusOfNewPlanytaryObject + 1;
        NewPlanytaryGameObject.transform.parent = NewOrbit.transform;
        NewPlanytaryGameObject.transform.localPosition = new Vector3(0, 2.22f, -1); 

            PlanetaryObject NewPlanytaryObject = NewPlanytaryGameObject.GetComponent<PlanetaryObject>();
            NewPlanytaryObject.Kind = kindOfNewPlanytaryObject;
            NewPlanytaryObject.Mass = massOfNewPlanytaryObject;
            NewPlanytaryObject.Radius = radiusOfNewPlanytaryObject;
            NewPlanytaryObject.orbit = NewOrbit.transform;

            Array.Resize(ref planetarySystem.planetaryObjects, planetarySystem.planetaryObjects.Length + 1);
            planetarySystem.planetaryObjects[planetarySystem.planetaryObjects.Length - 1] = NewPlanytaryObject;



          GameObject newPlanytaryObjectInfo = Instantiate(planytaryObjectInfoPrefab);
          newPlanytaryObjectInfo.GetComponent<Transform>().parent = infoContent;
          newPlanytaryObjectInfo.GetComponent<TextMeshProUGUI>().text = quantity + ") Kind: " + kindOfNewPlanytaryObject + " Mass: " + massOfNewPlanytaryObject + " Radius: " + radiusOfNewPlanytaryObject;


            quantity -= 1;
       }

    }

    
    
}
