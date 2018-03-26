using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowMid : MonoBehaviour {

    Camera cam = GameObject.Find("Camera").GetComponent<Camera>(); //Camera to use
    //Vector3 screenMid = cam.ViewportToWorldPointVector3(0.5, 0.5, cam.nearClipPlane));

    //var target : Transform; //Target to point at (you could set this to any gameObject dynamically)
//private var targetPos : Vector3; //Target position on screen
//private var screenMiddle : Vector3; //Middle of the screen

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = GameObject.FindGameObjectWithTag("Active").transform.position;
    }
}
