
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    //NOTE: THIS SCRIPT IS FOR PC, I DON'T KNOW HOW TO CONVERT THE INPUTS TO TOUCHSCREEN. If you know just do it :) thnx 

    public float panSpeed = 30f;
    public float panBorder = 10f;

    private bool doMovement = true;

    public float scrollSpeed = 5f;
    public float minY = 15f;
    public float maxY = 80f;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) //Press Escape to Enable/Disable Movement
            doMovement = !doMovement;
        if (!doMovement)
            return;

        //Camera Movement
           //The assignment of directions (in Vector3) is weird because my axes are misplaced in this scene
        if (Input.GetKey("w"))
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); //Vector3.forward = new Vector3(0, 0, 1) NOTE: WE MOVE THE CAMERA N THE GLOBAL(world) AXES NOT LOCAL(self), otherwise we will be zooming in instead of going up
        if (Input.GetKey("s"))
            transform.Translate(Vector3.right *panSpeed *Time.deltaTime, Space.World); //Vector3.forward = new Vector3(0, 0, 1) NOTE: WE MOVE THE CAMERA N THE GLOBAL(world) AXES NOT LOCAL(self), otherwise we will be zooming in instead of going up
        if (Input.GetKey("d"))
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //Vector3.forward = new Vector3(0, 0, 1) NOTE: WE MOVE THE CAMERA N THE GLOBAL(world) AXES NOT LOCAL(self), otherwise we will be zooming in instead of going left
        if (Input.GetKey("a"))
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); //Vector3.back = -Vector3.forward

        //Zooming
        float scroll = Input.GetAxis("Mouse ScrollWheel"); //To Get the name of an input goto Edit->Proj Settings->Input.
        Vector3 pos = transform.position;
        pos.y -= scroll *1000 *scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY); //Limiting zoom
        transform.position = pos;
    }
}
