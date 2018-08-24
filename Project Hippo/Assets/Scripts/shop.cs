
using UnityEngine;

public class shop : MonoBehaviour {

    BuildManager buildManager;

    [Header("Attributes")]
    public LandAnimalBlueprint Hippo;
    public LandAnimalBlueprint Elephant;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseHippo()
    {
        Debug.Log("Hippo Selected");
        buildManager.SetLandAnimal(Hippo); //Telling the BuildManager that the objectToBuild chosen is this prefab
    }
    public void PurchaseElephant()
    {
        Debug.Log("Elephant Selected");
        buildManager.SetLandAnimal(Elephant); //Telling the BuildManager that the objectToBuild chosen is this prefab
    }

}
