using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject target;
    Vector3 velocity;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerTarget = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, playerTarget, ref velocity, .5f);
	}
}
