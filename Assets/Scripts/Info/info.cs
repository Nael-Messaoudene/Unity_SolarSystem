using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    void Start()
    {
     Debug.Log(target.name);
    }
}
