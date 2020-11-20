using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    [Header("Required")]

    public GameObject target; //target to rotate around


    [Header("Mouse")]

    [Range(0.01f, 10)]//slider
    public float mouseSensitivity = 2f; //sensitivity of the mouse

    public bool invertYAxis = false; //whether or not to invert the y axis

    [Range(10f, 100f)]
    public float scrollSpeed = 50f; //zoom in speed


    [Header("Zooming")]

    [Range(0f, 1000f)]
    public float minZoom = 15f; //closest you can zoom in

    [Range(0f, 1000f)]
    public float maxZoom = 300f; //furthest you can zoom out


    [Header("Default Positioning")]

    [Range(0f, 1000f)]
    public float distance = 150f; //default distance from the target

    public Vector2 defaultRotation = new Vector2(45, 0); //default rotation around the target

 
    void Start()
    {
        //set camera rotation
        transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y, 0);

        //set distance
        if (distance < minZoom)
            distance = minZoom;       
    }


    void LateUpdate() //LateUpdate moves the camera after moving other objects ( after Update() )
    {
        //get input
        float hSpeed = Input.GetAxis("Mouse X") * mouseSensitivity;
        float vSpeed = Input.GetAxis("Mouse Y") * mouseSensitivity;

        float wheel = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        if(Input.GetMouseButton(0)) {

            //invert
            if (!invertYAxis) {
                vSpeed *= -1;
            }

            //rotate
            transform.Rotate(0, hSpeed, 0, Space.World); //Space.World means the rotating does not depend on the current rotation of the object
            transform.Rotate(vSpeed, 0, 0, Space.Self); //Space.Self is the default, left it there for clarity

            //check if in bounds
            if (transform.rotation.eulerAngles.x < 90 && transform.rotation.eulerAngles.x > 0 && transform.rotation.eulerAngles.z > 179) //looking too far up
                transform.Rotate(transform.rotation.eulerAngles.x - 90, 0, 0);
            if (transform.rotation.eulerAngles.x > 270 && transform.rotation.eulerAngles.x <= 360 && transform.rotation.eulerAngles.z > 179) //looking too far down
                transform.Rotate(transform.rotation.eulerAngles.x - 270, 0, 0);           
        }

        //zoom
        if (distance - wheel < minZoom)
            distance = minZoom;
        else if (distance - wheel > maxZoom)
            distance = maxZoom;
        else
            distance -= wheel;

        transform.position = -1 * transform.forward * distance;
    }
}
