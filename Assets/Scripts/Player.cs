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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .03f);
            gameObject.GetComponent<Animator>().Play("move");
            
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "poi")
        {
            startMove = false;
            gameObject.GetComponent<Animator>().Play("idle");
            if(collision.gameObject.name!="endpoi") gameController.displayEvent();
            GameObject[] babyWagons = GameObject.FindGameObjectsWithTag("BabyWagon");
            foreach (GameObject g in babyWagons)
            {
                g.GetComponent<BabyWagon>().startMove = false;
                g.GetComponent<Animator>().Play("idle", 0, Random.Range(0f, 1f));
            }
        }
    }
    public void setTarget(GameObject gameObject)
    {
        target = gameObject;
        startMove = true;
        GameObject[] babyWagons = GameObject.FindGameObjectsWithTag("BabyWagon");
        foreach (GameObject g in babyWagons)
        {
            g.GetComponent<BabyWagon>().startMove = true;
            g.GetComponent<Animator>().Play("move", 0, Random.Range(0f, 1f));
        }
    }
}
