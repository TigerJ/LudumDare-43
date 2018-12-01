using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    GameObject target;
    GameController gameController;
    bool startMove;
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (startMove == true)
        {
            Debug.Log("start moving");
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .05f);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "poi")
        {
            startMove = false;
            gameController.displayEvent();
        }
    }
    public void setTarget(GameObject gameObject)
    {
        target = gameObject;
        startMove = true;
    }
}
