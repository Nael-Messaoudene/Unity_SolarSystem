using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float factor;
    public float rotationSpeed;
    public float rotateAroundSpeed;
    public Transform target;
  //  public int speed;

    void Update()
    {
        //turn around something
        transform.RotateAround(target.transform.position, target.transform.up, rotateAroundSpeed*Time.deltaTime);
        
        transform.Rotate(0,rotationSpeed * Time.deltaTime,0);

    }

    public void SpeedAjustment(float speedAjust){

        rotationSpeed = speedAjust * factor;
        rotateAroundSpeed = speedAjust * factor;
    }
}
