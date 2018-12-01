using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWagon : MonoBehaviour {
    public GameObject Target;
    public bool startMove;

	// Use this for initialization

    void Update()
    {
        if (startMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, .03f);
        }
    }
}
