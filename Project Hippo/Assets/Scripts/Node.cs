
using UnityEngine;
using UnityEngine.EventSystems; //for UI in OnMouseEnter

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Renderer rend; //NOT renderer since it's already a Unity keyword
    private Color startColor;

    private Vector3 positionOffset = new Vector3 (0f, 0.5f, 0f); //BECAUSE when landAnimal is created, its base is in the node so we need to level it up on the Y axis
    [Header("Optional input")]
    public GameObject landAnimal; //if you want the user to start with lands already in place

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();//Getting the renderer of the object
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown() //Called by Unity when we press the Mouse (while hovering on the object)
    {
        if (!buildManager.CanBuild)
            return; //To avoid building anything that is null -> avoid errors
        if (EventSystem.current.IsPointerOverGameObject())
            return; //To Prevent Clicking on a Node when Selecting a LandAnimal (because Nodes can overlay/be next to Lands and we don't want a player to click on one by accident)

        if (landAnimal != null)
        {
            Debug.Log("Can't build here. There is already an item");
            //Selling
            //Repairing
            //Upgrading
            return;
        }

        buildManager.BuildLandAnimalOn(this);
    }

    void OnMouseEnter() //Called by Unity everytime the mouse passes by the collider of this object
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return; //To Prevent Clicking on a Node when Selecting a LandAnimal (because Nodes can overlay/be next to Lands and we don't want a player to click on one by accident)
        if (!buildManager.CanBuild)
            return; //Only WHEN A Animals IS SELECTED change color on hover BECAUSE otherwise the Nodes will Change color on hover EVEN IF NO Animals IS Selected which is Confusing
        if (buildManager.HasMoney)
            rend.material.color = hoverColor; //Changing the material color of object (from renderer) on hover
        else
            rend.material.color = Color.red;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
