﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLookAtTarget : MonoBehaviour
{
   	public GameObject target; // the target that the camera should look at

   public TMPro.TextMeshProUGUI title;

   public string titleData;

   public TMPro.TextMeshProUGUI size;
   public string sizeData;

	void Start() {
		if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("ChangeLookAtTarget target not specified. Defaulting to parent GameObject");
		}
	}

	// Called when MouseDown on this gameObject
	void OnMouseDown () {
		// change the target of the LookAtTarget script to be this gameobject.
		LookAtTarget1.target = target;
		// change the field of view on the perspective camera based on the distance from center of world, clamp it to a reasonable field of view
        Camera.main.fieldOfView = Mathf.Clamp(60 * target.transform.localScale.x, 1, 100);

        title.text = titleData;
        size.text = sizeData;
	}
}
