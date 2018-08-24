using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script Contains all the information of a Land/Animal. This class (script) will be called in shop
[System.Serializable] //Enables us to see the fields in the Inspector EVEN IF NOT Assigned to any object (since we removed MonoBehaviour). Since we acces this class through Shop script, the items below will be visible in Inspector of objects with the Shop script
public class LandAnimalBlueprint
{
    public GameObject prefab;
    public int cost;
}
