using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Transform target;
    public Transform selfRotateTarget = null;
    public int speed;
    public int selfRotateSpeed;
    void Update()
    {
        //turn around something
        transform.RotateAround(target.transform.position, target.transform.up, speed*Time.deltaTime);
        
        //rotate on himself
        transform.RotateAround(selfRotateTarget.transform.position, selfRotateTarget.transform.up, selfRotateSpeed*Time.deltaTime);

    }
}
