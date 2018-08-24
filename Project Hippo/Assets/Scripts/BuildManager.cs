using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance; //this var is a refrence to the Script

    void Awake() //Singleton instance:
    {
        if (instance != null)
            Debug.Log("More than one BuildManager in scene!");
        instance = this; //Everytime we start the game, there will only be one common BuildManager to all objects (Nodes). This Script is going to be put in this instance var which can be accessed from anywhere
    }

    public GameObject HippoPrefab;
    public GameObject ElephantPrefab;

    private LandAnimalBlueprint objectToBuild;


    public bool CanBuild { get { return objectToBuild != null; } }//Used in Node so if CanBuild=true it means that we chose a landAnimal, so the Node will change color on hover indicating that we can build
    public bool HasMoney { get { return PlayerStats.Money >= objectToBuild.cost; } } //To change hoverColor to red if  Player doesn't have enough money but is clicking on Node...

    public void SetLandAnimal (LandAnimalBlueprint landAnimal)
    {
        objectToBuild = landAnimal;
    }

    public void BuildLandAnimalOn(Node node)
    {
        if (PlayerStats.Money < objectToBuild.cost)
        {
            Debug.Log("NOT ENOGH MONEY!");
            return;
        }
        PlayerStats.Money -= objectToBuild.cost;

        GameObject landAnimal = (GameObject)Instantiate(objectToBuild.prefab, node.GetBuildPosition(), Quaternion.identity); //Remember to CAST! Adding Offset because the landAnimal base is Not ON Node (but IN it) on creation        
        node.landAnimal = landAnimal;
    }
}