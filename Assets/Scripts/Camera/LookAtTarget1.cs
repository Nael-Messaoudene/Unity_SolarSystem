using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget1 : MonoBehaviour
{
    // Start is called before the first frame update
    	static public GameObject target; // the target that the camera should look at

	void Start () {
		if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("LookAtTarget target not specified. Defaulting to parent GameObject");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
			transform.LookAt(target.transform);
	}
}
